using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO;
using WebHotel.DTO.DiscountTypeDtos;
using WebHotel.Repository.AdminRepository.DiscountTypeRepository;

namespace WebHotel.Controllers.AdminController;

[ApiController]
[ApiVersion("2.0")]
[Route("v{version:apiVersion}/admin/discount-type/")]
public class DiscountTypeAdminController : ControllerBase
{
    private readonly IDiscountTypeAdminRepository _discountType;

    public DiscountTypeAdminController(IDiscountTypeAdminRepository discountType)
    {
        _discountType = discountType;
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update([FromQuery] int? id, [FromBody] DiscountTypeResponseDto discountTypeDto)
    {
        var result = await _discountType.Update(id, discountTypeDto);
        if (result.StatusCode == 1)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(DiscountTypeRequestDto discountTypeDto)
    {
        var result = await _discountType.Create(discountTypeDto);
        if (result.StatusCode == 1)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet]
    [Route("get-all")]
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
    [Route("delete")]
    public async Task<StatusDto> Delete(int? id)
    {
        return await _discountType.Delete(id);
    }
}
