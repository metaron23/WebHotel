using AutoMapper;
using Database.Data;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using WebHotel.DTO;
using WebHotel.DTO.ServiceAttachDtos;

namespace WebHotel.Repository.AdminRepository.ServiceAttachRepository
{
    public class ServiceAttachRepository : IServiceAttachRepository
    {
        private readonly IMapper _mapper;
        private readonly MyDBContext _context;

        public ServiceAttachRepository(IMapper mapper, MyDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<StatusDto> Create(ServiceAttachDto serviceAttachDto)
        {
            var serviceAttach = _mapper.Map<ServiceAttach>(serviceAttachDto);
            try
            {
                await _context.AddAsync(serviceAttach);
                await _context.SaveChangesAsync();
                return new StatusDto { StatusCode = 1, Message = "Created successfully" };
            }
            catch (Exception ex)
            {
                return new StatusDto { StatusCode = 0, Message = ex.InnerException?.Message };
            }
        }

        public bool Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ServiceAttach>> GetAll()
        {
            return await _context.ServiceAttaches.AsNoTracking().ToListAsync();
        }
    }
}
