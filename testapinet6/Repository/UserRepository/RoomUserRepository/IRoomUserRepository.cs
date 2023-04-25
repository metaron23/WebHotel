using WebHotel.DTO.RoomDtos;

namespace WebHotel.Repository.UserRepository.RoomUserRepository
{
    public interface IRoomUserRepository
    {
        Task<IEnumerable<RoomResponseDto>> GetAll();

        Task<IEnumerable<RoomResponseDto>> GetAllBy(DateTime? checkIn, DateTime? checkOut, decimal? price, string? typeRoomName, float? star, int? peopleNumber);

        Task<RoomResponseDto> GetById(string id);
        Task<RoomSearchDto> GetRoomSearch();
    }
}
