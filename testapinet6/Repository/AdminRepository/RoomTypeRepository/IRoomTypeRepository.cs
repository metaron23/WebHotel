using WebHotel.DTO;
using WebHotel.DTO.RoomTypeDtos;

namespace WebHotel.Repository.AdminRepository.RoomTypeRepository
{
    public interface IRoomTypeRepository
    {
        Task<StatusDto> Create(RoomTypeRequestDto roomTypeCreateDto);
    }
}
