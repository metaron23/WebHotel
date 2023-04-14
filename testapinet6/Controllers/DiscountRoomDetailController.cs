using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebHotel.DTO.DiscountRoomDetailDtos;
using WebHotel.Repository.DiscountRoomDetailRepository;

namespace WebHotel.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DiscountRoomDetailController : ControllerBase
    {
        private readonly IDiscountRoomDetailRepository _discountRoomDetailRepository;

        public DiscountRoomDetailController(IDiscountRoomDetailRepository discountRoomDetailRepository)
        {
            _discountRoomDetailRepository = discountRoomDetailRepository;
        }

        [HttpPost]
        [Route("/discount-room-detail/create")]
        public async Task<IActionResult> Create(DiscountRoomDetailRequest discountRoomDetailRequest)
        {
            var email = User.FindFirst(ClaimTypes.Email)!.Value;
            var result = await _discountRoomDetailRepository.Create(discountRoomDetailRequest, email);
            if (result.StatusCode == 1)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
