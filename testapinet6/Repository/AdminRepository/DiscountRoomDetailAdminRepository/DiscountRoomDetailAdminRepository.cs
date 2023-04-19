using AutoMapper;
using Database.Data;
using Database.Models;
using WebHotel.DTO;
using WebHotel.DTO.DiscountRoomDetailDtos;

namespace WebHotel.Repository.AdminRepository.DiscountRoomDetailRepository
{
    public class DiscountRoomDetailADminRepository : IDiscountRoomDetailAdminRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public DiscountRoomDetailADminRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<StatusDto> Create(DiscountRoomDetailRequest discountRoomDetailRequest, string email)
        {
            var user = _context.ApplicationUsers.SingleOrDefault(a => a.Email == email);
            if (user != null)
            {
                var discountDetail = _mapper.Map<DiscountRoomDetail>(discountRoomDetailRequest);
                discountDetail.CreatorId = user.Id;
                try
                {
                    await _context.AddAsync(discountDetail);
                    await _context.SaveChangesAsync();
                    return new StatusDto { StatusCode = 1, Message = "Created successfully" };
                }
                catch { }
            }
            return new StatusDto { StatusCode = 0, Message = "Create discount error" };
        }
    }
}
