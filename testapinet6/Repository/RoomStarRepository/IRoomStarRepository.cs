using WebHotel.DTO;
using WebHotel.DTO.RoomStarDtos;

namespace WebHotel.Repository.RoomStarRepository
{
    public interface IRoomStarRepository
    {
        Task<StatusDto> Create(RoomStarRequestDto roomStarRequestDto);
    }
}
