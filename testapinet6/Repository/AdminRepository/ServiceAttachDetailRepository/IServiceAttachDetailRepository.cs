using WebHotel.DTO;
using WebHotel.DTO.ServiceAttachDetailDtos;

namespace WebHotel.Repository.AdminRepository.ServiceAttachDetailRepository
{
    public interface IServiceAttachDetailRepository
    {
        Task<StatusDto> Create(ServiceAttachDetailRequestDto serviceAttach);

        Task<IEnumerable<ServiceAttachDetailResponseDto>> GetAll();

        Task<StatusDto> Delete(int? id);
    }
}
