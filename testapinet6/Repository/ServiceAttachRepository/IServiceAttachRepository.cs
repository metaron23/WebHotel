using WebHotel.DTO;
using WebHotel.DTO.ServiceAttachDtos;
using WebHotel.Models;

namespace WebHotel.Repository.AttachServiceRepository
{
    public interface IServiceAttachRepository
    {
        Task<StatusDto> Create(ServiceAttachDto serviceAttach);

        Task<IEnumerable<ServiceAttach>> GetAll();

        bool Delete(int? id);
    }
}
