﻿using AutoMapper;
using Database.Data;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using WebHotel.DTO;
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
        public async Task<StatusDto> Create(ReservationCreateDto reservationCreateDto, string email)
        {
            var reservationExists = _context.Reservations.Where(a => a.EndDate < reservationCreateDto.EndDate).Where(a => a.StartDate > reservationCreateDto.EndDate);
            if (reservationExists is null)
            {
                var room = _context.Rooms.AsNoTracking().SingleOrDefault(a => a.Id == reservationCreateDto.RoomId)!;

                var user = _context.Users.AsNoTracking().SingleOrDefault(a => a.Email == email)!;

                if (room is not null || user is not null)
                {
                    var reservation = _mapper.Map<Reservation>(reservationCreateDto);

                    reservation.UserId = user.Id;

                    reservation.RoomPrice = (decimal)(room!.DiscountPrice == null ? room.CurrentPrice : room.DiscountPrice)!;

                    var startDate = reservationCreateDto.StartDate!.Value;

                    reservation.StartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 12, 00, 00);

                    reservation.EndDate = reservation.StartDate.AddDays((double)reservationCreateDto.NumberOfDay!);

                    reservation.DepositEndAt = startDate.AddMinutes(30);

                    reservation.ReservationPrice = reservation.RoomPrice * (decimal)reservation.NumberOfDay;

                    await _context.Reservations.AddAsync(reservation);
                    await _context.SaveChangesAsync();
                    return new StatusDto { StatusCode = 1, Message = "Successful booking" };
                }
                return new StatusDto { StatusCode = 0, Message = "Booking failed" };
            }
            return new StatusDto { StatusCode = 0, Message = "Room is Booked" };
        }
    }
}
