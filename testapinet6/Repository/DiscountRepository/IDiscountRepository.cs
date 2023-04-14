using WebHotel.DTO;
using WebHotel.DTO.DiscountDtos;

namespace WebHotel.Repository.DiscountRepository
{
    public interface IDiscountRepository
    {
        Task<StatusDto> Create(DiscountRequestDto discountRequestDto, string Email);
    }
}
