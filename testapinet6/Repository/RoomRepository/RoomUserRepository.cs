using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using WebHotel.Data;
using WebHotel.DTO.RoomDtos;
using WebHotel.Models;
using WebHotel.Service.FileService;

namespace WebHotel.Repository.RoomRepository
{
    public partial class RoomRepository : IRoomRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public RoomRepository(MyDBContext context, IMapper mapper, IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task CheckDiscount(Room room)
        {
            //_context.Rooms.Select(a => _context.DiscountRoomDetails)
            var discount = await _context.DiscountRoomDetails.Include(a => a.Discount)
                .Where(a => a.RoomId == room.Id).Where(a => a.Discount.StartAt <= DateTime.Now).Where(a => a.Discount.EndAt >= DateTime.Now).Where(a => a.Discount.AmountUse > 0).SingleOrDefaultAsync();
            if (discount != null)
            {
                room.DiscountPrice = (room.CurrentPrice * discount.Discount.DiscountPercent) / 100;
            }
        }

        public async Task<IEnumerable<RoomResponseDto>> GetAll()
        {
            var roomBases = await _context.Rooms.Include(a => a.RoomType).AsNoTracking().ToListAsync();
            var roomResponse = new RoomResponseDto();
            var roomResponses = new List<RoomResponseDto>();
            foreach (var item in roomBases)
            {
                await CheckDiscount(item);
                roomResponse = _mapper.Map<RoomResponseDto>(item);
                roomResponse.RoomTypeName = item.RoomType.TypeName;
                roomResponses.Add(roomResponse);
            }
            return roomResponses;
        }

        [return: MaybeNull]
        public async Task<RoomResponseDto> GetById(string id)
        {
            var roomBases = _context.Rooms.Include(a => a.RoomType).AsNoTracking().SingleOrDefault(a => a.Id == id);
            if (roomBases != null)
            {
                var roomResponse = new RoomResponseDto();
                await CheckDiscount(roomBases);
                roomResponse = _mapper.Map<RoomResponseDto>(roomBases);
                roomResponse.RoomTypeName = roomBases.RoomType.TypeName;
                return roomResponse;
            }
            return default;
        }

        public async Task<IEnumerable<RoomResponseDto>> GetAllBy(DateTime? checkIn, DateTime? checkOut, decimal? price, int? typeRoomId, float? star, int? peopleNumber)
        {
            var roomBasesQuery = _context.Rooms.Include(a => a.RoomType).AsNoTracking().AsQueryable();
            if (price != null)
            {
                roomBasesQuery = roomBasesQuery.Where(a => a.CurrentPrice <= price || (a.DiscountPrice > 0 && a.DiscountPrice <= price));
            }
            if (typeRoomId != null)
            {
                roomBasesQuery = roomBasesQuery.Where(a => a.RoomTypeId == typeRoomId);
            }
            if (star != null)
            {
                roomBasesQuery = roomBasesQuery.Where(a => a.StarSum == star);
            }
            if (peopleNumber != null)
            {
                roomBasesQuery = roomBasesQuery.Where(a => a.PeopleNumber == peopleNumber);
            }
            var roomResponse = new RoomResponseDto();
            var roomResponses = new List<RoomResponseDto>();
            var roomBases = await roomBasesQuery.ToListAsync();
            foreach (var item in roomBases)
            {
                await CheckDiscount(item);
                roomResponse = _mapper.Map<RoomResponseDto>(item);
                roomResponse.RoomTypeName = item.RoomType.TypeName;
                roomResponses.Add(roomResponse);
            }
            return roomResponses;
        }

        public async Task<RoomSearchDto> GetRoomSearch()
        {
            var roomSearch = new RoomSearchDto();
            roomSearch.MaxPerson = await _context.Rooms.MaxAsync(a => a.PeopleNumber);
            roomSearch.MaxPrice = await _context.Rooms.MaxAsync(a => a.CurrentPrice);
            roomSearch.ServiceAttachs = await _context.ServiceAttaches.Select(a => a.Name).ToListAsync();
            return roomSearch;
        }
    }
}
