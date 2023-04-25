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

        public async Task<StatusDto> Create(ServiceAttachRequestDto serviceAttachDto)
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

        public async Task<StatusDto> Delete(int? id)
        {
            var serviceAttach = await _context.ServiceAttaches.SingleOrDefaultAsync(a => a.Id == id);
            if (serviceAttach is not null)
            {
                try
                {
                    _context.ServiceAttaches.Remove(serviceAttach);
                    await _context.SaveChangesAsync();
                    return new StatusDto { StatusCode = 1, Message = "Successfull deleted " };
                }
                catch (Exception ex)
                {
                    return new StatusDto { StatusCode = 0, Message = ex.InnerException?.Message };
                }
            }
            return new StatusDto { StatusCode = 0, Message = "Id not found!" };
        }

        public async Task<IEnumerable<ServiceAttachResponseDto>> GetAll()
        {
            var serviceAttach = _mapper.Map<List<ServiceAttachResponseDto>>(await _context.ServiceAttaches.AsNoTracking().ToListAsync());
            return serviceAttach;
        }
    }
}
