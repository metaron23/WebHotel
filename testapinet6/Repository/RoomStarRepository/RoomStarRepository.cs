using AutoMapper;
using WebHotel.Data;
using WebHotel.DTO;
using WebHotel.DTO.RoomStarDtos;
using WebHotel.Models;

namespace WebHotel.Repository.RoomStarRepository
{
    public class RoomStarRepository : IRoomStarRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public RoomStarRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatusDto> Create(RoomStarRequestDto roomStarRequestDto)
        {
            var room = _context.Rooms.SingleOrDefault(a => a.Id == roomStarRequestDto.RoomId);
            if (room is not null)
            {
                await _context.AddAsync(_mapper.Map<RoomStar>(roomStarRequestDto));
                room.StarValue += roomStarRequestDto.Number;
                room.StarAmount++;
                room.StarSum = room.StarValue / room.StarAmount;
                await _context.SaveChangesAsync();
                return new StatusDto { StatusCode = 1, Message = "Successful comment!" };
            }
            return new StatusDto { StatusCode = 0, Message = "Id room not found!" };
        }
    }
}
