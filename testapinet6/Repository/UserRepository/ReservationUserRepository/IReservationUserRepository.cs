using WebHotel.DTO;
using WebHotel.DTO.ReservationDtos;

namespace WebHotel.Repository.UserRepository.ReservationRepository
{
    public interface IReservationUserRepository
    {
        Task<StatusDto> Create(ReservationCreateDto reservationCreateDto, string email);
    }
}
