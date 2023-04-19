using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO;
using WebHotel.DTO.DiscountTypeDtos;
using WebHotel.Repository.AdminRepository.DiscountTypeRepository;

namespace WebHotel.Controllers.AdminController;

[ApiController]
[ApiVersion("2.0")]
public class DiscountTypeAdminController : ControllerBase
{
    private readonly IDiscountTypeAdminRepository _discountType;

    public DiscountTypeAdminController(IDiscountTypeAdminRepository discountType)
    {
        _discountType = discountType;
    }

    [HttpPost]
    [Route("admin/discount-type/create")]
    public async Task<IActionResult> Create(DiscountTypeRequestDto discountTypeDto)
    {
        var result = await _discountType.Create(discountTypeDto);
        if (result.StatusCode == 1)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPut]
    [Route("admin/discount-type/update")]
    public async Task<IActionResult> Update([FromRoute] int? id, [FromBody] DiscountTypeResponseDto discountTypeDto)
    {
        var result = await _discountType.Update(id, discountTypeDto);
        if (result.StatusCode == 1)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet]
    [Route("admin/discount-type/get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _discountType.GetAll();
        if (result is null)
        {
            return NotFound(result);
        }
        return Ok(result);
    }

    [HttpDelete]
    [Route("admin/discount-type/delete")]
    public async Task<StatusDto> Delete(int? id)
    {
        return await _discountType.Delete(id);
    }
}
