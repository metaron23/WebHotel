using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebHotel.DTO.DiscountDtos;
using WebHotel.Repository.DiscountRepository;

namespace WebHotel.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpPost]
        [Route("/discount/create")]
        public async Task<IActionResult> Create(DiscountRequestDto discountRequestDto)
        {
            var email = User.FindFirst(ClaimTypes.Email)!.Value;
            var result = await _discountRepository.Create(discountRequestDto, email);
            if (result.StatusCode == 1)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
