using AutoMapper;
using Database.Data;
using Database.Models;
using WebHotel.DTO;
using WebHotel.DTO.RoomTypeDtos;

namespace WebHotel.Repository.RoomTypeRepository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public RoomTypeRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatusDto> Create(RoomTypeRequestDto roomTypeCreateDto)
        {
            try
            {
                await _context.AddAsync(_mapper.Map<RoomType>(roomTypeCreateDto));
                await _context.SaveChangesAsync();
                return new StatusDto { StatusCode = 1, Message = "Successfully created new!" };
            }
            catch
            {
                return new StatusDto { StatusCode = 0, Message = "Type name already exists!" };
            }
        }
    }
}
