using AutoMapper;
using Database.Data;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using WebHotel.DTO;
using WebHotel.DTO.ServiceAttachDetailDtos;

namespace WebHotel.Repository.AdminRepository.ServiceAttachDetailRepository;

public class ServiceAttachDetailRepository : IServiceAttachDetailRepository
{
    private readonly IMapper _mapper;
    private readonly MyDBContext _context;

    public ServiceAttachDetailRepository(IMapper mapper, MyDBContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<StatusDto> Create(ServiceAttachDetailRequestDto serviceAttachDto)
    {
        var serviceAttach = _mapper.Map<ServiceAttachDetail>(serviceAttachDto);
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
        var serviceAttachDetail = await _context.ServiceAttachDetails.SingleOrDefaultAsync(a => a.Id == id);
        if (serviceAttachDetail is not null)
        {
            try
            {
                _context.ServiceAttachDetails.Remove(serviceAttachDetail);
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

    public async Task<IEnumerable<ServiceAttachDetailResponseDto>> GetAll()
    {
        var serviceAttach = _mapper.Map<List<ServiceAttachDetailResponseDto>>(await _context.ServiceAttachDetails.AsNoTracking().OrderByDescending(a => a.Id).ToListAsync());
        return serviceAttach;
    }
}
