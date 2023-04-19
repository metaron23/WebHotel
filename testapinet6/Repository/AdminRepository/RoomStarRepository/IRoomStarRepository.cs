using WebHotel.DTO;
using WebHotel.DTO.RoomStarDtos;

namespace WebHotel.Repository.AdminRepository.RoomStarRepository
{
    public interface IRoomStarRepository
    {
        Task<StatusDto> Create(RoomStarRequestDto roomStarRequestDto);
    }
}
