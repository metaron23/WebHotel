using WebHotel.DTO;
using WebHotel.DTO.RoomTypeDtos;

namespace WebHotel.Repository.RoomTypeRepository
{
    public interface IRoomTypeRepository
    {
        Task<StatusDto> Create(RoomTypeCreateDto roomTypeCreateDto);
    }
}
