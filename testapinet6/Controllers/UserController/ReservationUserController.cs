using AutoMapper;
using Database.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebHotel.Commom;
using WebHotel.DTO;
using WebHotel.DTO.ReservationDtos;
using WebHotel.Repository.UserRepository.ReservationRepository;
using WebHotel.Service.NotifiHubService;

namespace WebHotel.Controllers.UserController;

[ApiController]
[ApiVersion("1.0")]
[Authorize]
[Route("user/")]
public class ReservationUserController : ControllerBase
{
    private readonly IReservationUserRepository _reservationRepository;
    private readonly MyDBContext _context;
    private readonly IMapper _mapper;
    private readonly IHubContext<HubService, IHubService> _hubContext;

    public ReservationUserController(IReservationUserRepository reservationRepository, MyDBContext context, IMapper mapper, IHubContext<HubService, IHubService> hubContext)
    {
        _reservationRepository = reservationRepository;
        _context = context;
        _mapper = mapper;
        _hubContext = hubContext;
    }

    [HttpPost]
    [Route("reservation/create")]
    public async Task<IActionResult> Create(ReservationCreateDto reservationCreateDto)
    {
        var email = User.FindFirst(ClaimTypes.Email)!.Value;
        var result = await _reservationRepository.Create(reservationCreateDto, email);
        if (result.StatusCode == 1)
        {
            await _hubContext.Clients.Group(UserRoles.Admin).ReceiveMessage("admin", ": da nhan tin nhan");
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet]
    [Route("reservation/delete-if-failed")]
    public async Task<IActionResult> DeleteIfFailed(string id)
    {
        var email = User.FindFirst(ClaimTypes.Email)!.Value;
        var reservationPayment = await _context.ReservationPayments.SingleOrDefaultAsync(a => a.ReservationId == id);
        var reservation = await _context.Reservations.SingleOrDefaultAsync(a => a.Id == id);
        if (reservationPayment is not null)
        {
            if (reservationPayment?.Status == 1)
            {
                return BadRequest(new StatusDto { StatusCode = 0, Message = "Not delete booked successfully" });
            }
            else
            {
                _context.Remove(reservation!);
                await _context.SaveChangesAsync();
                return Ok(new StatusDto { StatusCode = 1, Message = "Deleted successfully" });
            }
        }
        else
        {
            _context.Remove(reservation!);
            await _context.SaveChangesAsync();
            return Ok(new StatusDto { StatusCode = 1, Message = "Deleted successfully" });
        }
    }

    [HttpGet]
    [Route("reservation/get-successful")]
    public async Task<IActionResult> GetSuccessful()
    {
        var email = User.FindFirst(ClaimTypes.Email)!.Value;
        var user = await _context.ApplicationUsers.SingleOrDefaultAsync(a => a.Email == email);
        var reservationSuccessId = _context.ReservationPayments.Where(a => a.Status == 1).Select(a => a.ReservationId);
        var result = await _context.Reservations.Where(a => reservationSuccessId.Contains(a.Id)).Where(a => a.UserId == user!.Id).ToListAsync();
        return Ok(result);
    }
    [HttpPost]
    [Route("reservation/edit-info")]
    public async Task<IActionResult> EditInfo([FromBody] InfoEditReservationDto infoEditReservation, [FromQuery] string id)
    {
        var reservation = await _context.Reservations.SingleOrDefaultAsync(a => a.Id == id);
        if (reservation is not null)
        {
            _mapper.Map(infoEditReservation, reservation);
            await _context.SaveChangesAsync();
            return Ok();
        }
        return BadRequest();
    }
}

public class InfoEditReservationDto
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;
}
