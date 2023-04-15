using WebHotel.DTO;
using WebHotel.DTO.DiscountTypeDtos;

namespace WebHotel.Repository.DiscountTypeRepository
{
    public interface IDiscountTypeRepository
    {
        Task<StatusDto> Create(DiscountTypeCreateDto discountTypeDto);
    }
}
