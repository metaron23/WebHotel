using WebHotel.DTO;
using WebHotel.DTO.RoomDtos;

namespace WebHotel.Repository.RoomRepository
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomResponseDto>> GetAll();

        Task<IEnumerable<RoomResponseDto>> GetAllBy(DateTime? checkIn, DateTime? checkOut, decimal? price, int? typeRoomId, float? star, int? peopleNumber);

        Task<RoomResponseDto> GetById(string id);

        Task<StatusDto> Create(RoomCreateDto roomCreateDto);

        Task<RoomSearchDto> GetRoomSearch();
    }
}
