using WebHotel.Data;
using WebHotel.DTO;
using WebHotel.DTO.DiscountTypeDtos;
using WebHotel.Models;

namespace WebHotel.Repository.DiscountTypeRepository
{
    public class DiscountTypeRepository : IDiscountTypeRepository
    {
        private readonly MyDBContext _context;

        public DiscountTypeRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<StatusDto> Create(DiscountTypeCreateDto discountTypeDto)
        {
            if (_context.DiscountTypes.SingleOrDefault(a => a.Name == discountTypeDto.Name) != null)
            {
                return new StatusDto { StatusCode = 0, Message = "Create failed, name already exists" };
            }
            var discountType = new DiscountType
            {
                Name = discountTypeDto.Name!
            };
            try
            {
                await _context.AddAsync(discountType);
                await _context.SaveChangesAsync();
                return new StatusDto { StatusCode = 1, Message = "Created successfully" };
            }
            catch
            {
                return new StatusDto { StatusCode = 0, Message = "Create failed, error system" };
            }
        }
    }
}
