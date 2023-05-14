using AutoMapper;
using Database.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHotel.DTO.AccountDtos;

namespace WebHotel.Controllers.AdminController;

[ApiController]
//[Authorize(Roles = "Admin")]
[Route("v{version:apiVersion}/admin/account/")]
[ApiVersion("2.0")]
public class AccountAdminController : ControllerBase
{
    private readonly MyDBContext _context;
    private readonly IMapper _mapper;

    public AccountAdminController(MyDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var accounts = _mapper.Map<List<AccountResponseDto>>(await _context.ApplicationUsers.ToListAsync());

        return Ok(accounts);
    }


}
