using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebHotel.DTO.ReservationDtos;
using WebHotel.Repository.ReservationRepository;

namespace WebHotel.Controllers
{
    [ApiController]
    [Authorize(Roles = "User")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpPost]
        [Route("/user/reservation/create")]
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
}
