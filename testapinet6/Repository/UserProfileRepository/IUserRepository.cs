using WebHotel.DTO;
using WebHotel.DTO.UserDtos;

namespace WebHotel.Repository.UserProfileRepository
{
    public interface IUserRepository
    {
        Task<StatusDto> Update(UserProfileRequestDto user, string? email);
        UserProfileResponseDto Get(string? email);
    }
}
