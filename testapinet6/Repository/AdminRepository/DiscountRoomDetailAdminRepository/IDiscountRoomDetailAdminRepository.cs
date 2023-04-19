using WebHotel.DTO;
using WebHotel.DTO.DiscountRoomDetailDtos;

namespace WebHotel.Repository.AdminRepository.DiscountRoomDetailRepository
{
    public interface IDiscountRoomDetailAdminRepository
    {
        Task<StatusDto> Create(DiscountRoomDetailRequest discountRoomDetailRequest, string email);
    }
}
