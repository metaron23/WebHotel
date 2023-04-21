using WebHotel.DTO;
using WebHotel.DTO.RoomTypeDtos;

namespace WebHotel.Repository.AdminRepository.RoomTypeRepository
{
    public interface IRoomTypeRepository
    {
        Task<StatusDto> Create(RoomTypeRequestDto roomTypeCreateDto);
        Task<StatusDto> Update(int? id, RoomTypeRequestDto roomTypeRequestDto);
        Task<StatusDto> Delete(int? id);
        Task<IEnumerable<RoomTypeResponseDto>> GetAll();
    }
}
