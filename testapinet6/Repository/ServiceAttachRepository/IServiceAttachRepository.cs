using Database.Models;
using WebHotel.DTO;
using WebHotel.DTO.ServiceAttachDtos;

namespace WebHotel.Repository.ServiceAttachRepository
{
    public interface IServiceAttachRepository
    {
        Task<StatusDto> Create(ServiceAttachDto serviceAttach);

        Task<IEnumerable<ServiceAttach>> GetAll();

        bool Delete(int? id);
    }
}
