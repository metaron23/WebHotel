using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebHotel.DTO.DiscountDtos;
using WebHotel.Repository.AdminRepository.DiscountRepository;

namespace WebHotel.Controllers.AdminController;

[ApiController]
[Authorize(Roles = "Admin")]
[ApiVersion("2.0")]
public class DiscountAdminController : ControllerBase
{
    private readonly IDiscountAdminRepository _discountRepository;

    public DiscountAdminController(IDiscountAdminRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    [HttpPost]
    [Route("/admin/discount/create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DiscountRequestDto discountRequestDto)
    {
        var email = User.FindFirst(ClaimTypes.Email)!.Value;
        var result = await _discountRepository.Create(discountRequestDto, email);
        if (result.StatusCode == 1)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet]
    [Route("admin/discount/get-all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _discountRepository.GetAll());
    }

    [HttpGet]
    [Route("admin/discount/get-by-id")]
    public async Task<IActionResult> GetById(int? id)
    {
        var result = await _discountRepository.GetById(id);
        if (result != null)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet]
    [Route("admin/discount/get-by-search")]
    public IActionResult GetBySearch(string? discountCode, string? name, decimal? percentDiscount, DateTime? startAt, DateTime? endAt, string? nameType, string? creatorEmail)
    {
        return Ok(_discountRepository.GetBySearch(discountCode, name, percentDiscount, startAt, endAt, nameType, creatorEmail));
    }

    [HttpPut]
    [Route("admin/discount/update")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int? id, [FromBody] DiscountUpdateDto discountUpdateDto)
    {
        var result = await _discountRepository.Update(id, discountUpdateDto);
        if (result.StatusCode == 1)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete]
    [Route("admin/discount/delete")]
    public async Task<IActionResult> Delete(int? id)
    {
        var result = await _discountRepository.Delete(id);
        if (result.StatusCode == 1)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
