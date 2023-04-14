using WebHotel.DTO;
using WebHotel.DTO.ReservationDtos;

namespace WebHotel.Repository.ReservationRepository
{
    public interface IReservationRepository
    {
        Task<StatusDto> Create(ReservationCreateDto reservationCreateDto, string email);
    }
}
