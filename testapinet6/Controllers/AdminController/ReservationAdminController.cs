using AutoMapper;
using Database.Data;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebHotel.Controllers.AdminController;

[ApiController]
[ApiVersion("2.0")]
[Route("v{version:apiVersion}/admin/reservation/")]
//[Authorize]
public class ReservationAdminController : ControllerBase
{
    private readonly MyDBContext _context;
    private readonly IMapper _mapper;
    public ReservationAdminController(MyDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var reservations = await _context.Reservations.Include(a => a.Room).Include(a => a.ReservationPayment).Where(a => a.ReservationPayment != null).ToListAsync();
        reservations.ForEach(a => a.ReservationPayment = new ReservationPayment
        {
            Id = a.ReservationPayment.Id,
            Message = a.ReservationPayment.Message,
            CreateAt = a.ReservationPayment.CreateAt,
            PriceTotal = a.ReservationPayment.PriceTotal,
            OrderInfo = a.ReservationPayment.OrderInfo,
            OrderType = a.ReservationPayment.OrderType,
            PayType = a.ReservationPayment.PayType,
            Status = a.ReservationPayment.Status
        });
        if (reservations is null)
        {
            return NotFound();
        }
        var result = _mapper.Map<List<ReservationResponseAdminDto>>(reservations);
        return Ok(result);
    }

    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetById(string id)
    {
        var reservation = await _context.Reservations.Include(a => a.Room).Include(a => a.ReservationPayment).SingleOrDefaultAsync(a => a.Id == id);
        if (reservation is null)
        {
            return NotFound();
        }
        if (reservation.ReservationPayment != null)
        {
            reservation.ReservationPayment = new ReservationPayment
            {
                Id = reservation.ReservationPayment.Id,
                Message = reservation.ReservationPayment.Message,
                CreateAt = reservation.ReservationPayment.CreateAt,
                PriceTotal = reservation.ReservationPayment.PriceTotal,
                OrderInfo = reservation.ReservationPayment.OrderInfo,
                OrderType = reservation.ReservationPayment.OrderType,
                PayType = reservation.ReservationPayment.PayType,
                Status = reservation.ReservationPayment.Status
            };
        }
        var result = _mapper.Map<ReservationResponseAdminDto>(reservation);
        return Ok(result);
    }
}

public class ReservationResponseAdminDto
{
    public string Id { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public float NumberOfDay { get; set; }
    public DateTime EndDate { get; set; }
    public decimal RoomPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public decimal ReservationPrice { get; set; }
    public string RoomNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public bool Status { get; set; }
    public ReservationPayment ReservationPayment { get; set; } = null!;
}
