using AutoMapper;
using Database.Data;
using Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHotel.DTO;
using WebHotel.DTO.PaymentDtos;

namespace WebHotel.Controllers.UserController
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("user/")]
    public class PaymentUserController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public PaymentUserController(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("invoid/create")]
        public async Task<IActionResult> PayMent(PaymentRequestFullDto paymentRequestFull)
        {
            var reservation = await _context.Reservations.SingleOrDefaultAsync(a => a.Id == paymentRequestFull.ReservationId!);
            if (reservation is null)
            {
                return BadRequest(new StatusDto { StatusCode = 0, Message = "Reservation ID is not valid" });
            }
            var reservationPayment = _mapper.Map<ReservationPayment>(paymentRequestFull);
            reservationPayment.CreateAt = DateTime.Now;
            await _context.ReservationPayments.AddAsync(reservationPayment);
            if (paymentRequestFull.Status == 1)
            {
                InvoiceReservation invoid = new InvoiceReservation()
                {
                    PayAt = DateTime.Now,
                    PriceReservedRoom = reservation.ReservationPrice,
                    PriceService = _context.OrderServices.Where(a => a.ReservationId == reservation.Id).Sum(a => a.Price * a.Amount),
                    ReservationId = reservation.Id
                };
                await _context.InvoiceReservations.AddAsync(invoid);
            }
            await _context.SaveChangesAsync();
            return Ok(new StatusDto { StatusCode = 1, Message = "Successful" });
        }
    }
}
