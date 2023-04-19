using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebHotel.DTO.DiscountRoomDetailDtos;
using WebHotel.Repository.AdminRepository.DiscountRoomDetailRepository;

namespace WebHotel.Controllers.AdminController;

[ApiController]
[Authorize(Roles = "Admin")]
[ApiVersion("2.0")]
public class DiscountRoomDetailAdminController : ControllerBase
{
    private readonly IDiscountRoomDetailAdminRepository _discountRoomDetailRepository;

    public DiscountRoomDetailAdminController(IDiscountRoomDetailAdminRepository discountRoomDetailRepository)
    {
        _discountRoomDetailRepository = discountRoomDetailRepository;
    }

    [HttpPost]
    [Route("admin/discount-room-detail/create")]
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
