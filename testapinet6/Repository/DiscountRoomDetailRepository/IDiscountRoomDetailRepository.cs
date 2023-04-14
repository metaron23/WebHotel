using WebHotel.DTO;
using WebHotel.DTO.DiscountRoomDetailDtos;

namespace WebHotel.Repository.DiscountRoomDetailRepository
{
    public interface IDiscountRoomDetailRepository
    {
        Task<StatusDto> Create(DiscountRoomDetailRequest discountRoomDetailRequest, string email);
    }
}
