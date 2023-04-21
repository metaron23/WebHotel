using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebHotel.DTO.ReservationDtos;
using WebHotel.Repository.UserRepository.ReservationRepository;

namespace WebHotel.Controllers.UserController;

[ApiController]
[Authorize(Roles = "User")]
[ApiVersion("1.0")]
[Route("user/")]

public class ReservationUserController : ControllerBase
{
    private readonly IReservationUserRepository _reservationRepository;

    public ReservationUserController(IReservationUserRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    [HttpPost]
    [Route("reservation/create")]
    public async Task<IActionResult> Create(ReservationCreateDto reservationCreateDto)
    {
        var email = User.FindFirst(ClaimTypes.Email)!.Value;
        var result = await _reservationRepository.Create(reservationCreateDto, email);
        if (result.StatusCode == 1)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
