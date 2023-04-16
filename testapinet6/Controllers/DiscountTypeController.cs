using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO;
using WebHotel.DTO.DiscountTypeDtos;
using WebHotel.Repository.DiscountTypeRepository;

namespace WebHotel.Controllers;

[ApiController]
public class DiscountTypeController : ControllerBase
{
    private readonly IDiscountTypeRepository _discountType;

    public DiscountTypeController(IDiscountTypeRepository discountType)
    {
        _discountType = discountType;
    }

    [HttpPost]
    [Route("/discount-type/create")]
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
    [Route("/discount-type/update")]
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
    [Route("/discount-type/get-all")]
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
    [Route("/discount-type/delete")]
    public async Task<StatusDto> Delete(int? id)
    {
        return await _discountType.Delete(id);
    }
}
