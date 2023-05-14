using AutoMapper;
using Database.Data;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using WebHotel.DTO.ReservationDtos;

namespace WebHotel.Repository.UserRepository.ReservationRepository
{
    public class ReservationUserRepository : IReservationUserRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public ReservationUserRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReservationStatusDto> Create(ReservationCreateDto reservationCreateDto, string email)
        {
            if (reservationCreateDto.StartDate!.Value.Date >= DateTime.Now.Date && reservationCreateDto.EndDate!.Value.Date > reservationCreateDto.StartDate!.Value.Date)
            {
                var room = _context.Rooms.AsNoTracking().SingleOrDefault(a => a.Id == reservationCreateDto.RoomId)!;

                var user = _context.Users.AsNoTracking().SingleOrDefault(a => a.Email == email)!;
                if (room is not null && user is not null)
                {
                    var reservationExists = await _context.Reservations
                        .Include(a => a.ReservationPayment)
                        .Where(a =>
                        (a.EndDate <= reservationCreateDto.EndDate && a.EndDate >= reservationCreateDto.StartDate) ||
                        (a.StartDate <= reservationCreateDto.EndDate && a.StartDate >= reservationCreateDto.StartDate))
                        .Where(a => a.ReservationPayment.Status == 1)
                        .ToListAsync();
                    if (reservationExists.Count() == 0)
                    {
                        var reservation = _mapper.Map<Reservation>(reservationCreateDto);

                        reservation.UserId = user.Id;
                        reservation.RoomPrice = (decimal)(room!.DiscountPrice == null ? room.CurrentPrice : room.DiscountPrice)!;

                        var startDate = reservationCreateDto.StartDate!.Value;

                        reservation.StartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 12, 00, 00);
                        reservation.EndDate = reservation.StartDate.AddDays((double)reservationCreateDto.NumberOfDay!);
                        reservation.ReservationPrice = reservation.RoomPrice * (decimal)reservation.NumberOfDay;
                        try
                        {
                            await _context.Reservations.AddAsync(reservation);
                            await _context.SaveChangesAsync();
                            return new ReservationStatusDto { StatusCode = 1, Message = "Successful booking", ReservationId = reservation.Id };
                        }
                        catch (Exception ex)
                        {
                            return new ReservationStatusDto { StatusCode = 0, Message = ex.InnerException?.Message };
                        }
                    }
                    else
                    {
                        return new ReservationStatusDto { StatusCode = 0, Message = "Room is booked" };
                    }
                }
                else
                {
                    return new ReservationStatusDto { StatusCode = 0, Message = "Booking failed. Room or account not valid" };
                }
            }
            return new ReservationStatusDto { StatusCode = 0, Message = "Time failed" };
        }
    }
}
