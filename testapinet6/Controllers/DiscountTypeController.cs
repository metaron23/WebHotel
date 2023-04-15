using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO.DiscountTypeDtos;
using WebHotel.Repository.DiscountTypeRepository;

namespace WebHotel.Controllers
{
    [ApiController]
    public class DiscountTypeController : ControllerBase
    {
        private readonly IDiscountTypeRepository _discountType;

        public DiscountTypeController(IDiscountTypeRepository discountType)
        {
            _discountType = discountType;
        }

        [HttpPost]
        [Route("/discount-type/create")]
        public async Task<IActionResult> Create(DiscountTypeCreateDto discountTypeDto)
        {
            var result = await _discountType.Create(discountTypeDto);
            if (result.StatusCode == 1)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
