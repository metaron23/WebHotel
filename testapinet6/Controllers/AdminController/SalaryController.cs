using AutoMapper;
using Database.Data;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHotel.Commom;
using WebHotel.DTO;

namespace WebHotel.Controllers.AdminController;

[ApiController]
[ApiVersion("2.0")]
[Route("v{version:apiVersion}/admin/salary/")]
//[Authorize(Roles = "Admin")]
public class SalaryController : ControllerBase
{
    private readonly MyDBContext _context;
    private readonly IMapper _mapper;

    public SalaryController(MyDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(SalaryCreateDto salaryCreate)
    {
        var employeeId = await _context.ApplicationUserRoles.Include(a => a.Role).Where(a => a.Role!.Name == UserRoles.Employee || a.Role!.Name == UserRoles.Manager).Select(a => a.UserId).ToListAsync();

        var employee = await _context.ApplicationUsers.Where(a => employeeId.Contains(a.Id)).Where(a => a.Id == salaryCreate.EmployeeId).SingleOrDefaultAsync();

        if (employee is not null)
        {
            var check = await _context.Salarys.AsNoTracking().Where(a => a.WorkTime!.Value.Year == salaryCreate.WorkTime!.Value.Year).Where(a => a.WorkTime!.Value.Month == salaryCreate.WorkTime!.Value.Month).Where(a => a.EmployeeId == salaryCreate.EmployeeId).SingleOrDefaultAsync();
            if (check != null)
            {
                return BadRequest(new StatusDto { StatusCode = 0, Message = "Employee has been set salary for this month" });
            }
            await _context.AddAsync(_mapper.Map<Salary>(salaryCreate));
            await _context.SaveChangesAsync();
            return Ok(new StatusDto { StatusCode = 1, Message = "Created successfully" });
        }
        return NotFound();
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _context.Salarys.AsNoTracking().ToListAsync();
        if (result.Count == 0)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<List<SalaryResponseDto>>(result));
    }

    [HttpGet("delete")]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        var result = await _context.Salarys.SingleOrDefaultAsync(a => a.Id == id);
        if (result is null)
        {
            return NotFound();
        }
        _context.Remove(result);
        await _context.SaveChangesAsync();
        return Ok(new StatusDto { StatusCode = 1, Message = "Deleted successfully" });
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] SalaryCreateDto serviceRoom, [FromQuery] int id)
    {
        var result = await _context.Salarys.SingleOrDefaultAsync(a => a.Id == id);
        if (result is null)
        {
            return NotFound();
        }
        _mapper.Map(serviceRoom, result);
        await _context.SaveChangesAsync();
        return Ok(new StatusDto { StatusCode = 1, Message = "Updated successfully" });
    }
}

public class SalaryCreateDto
{
    public decimal BasicSalary { get; set; }
    public int NumberOfDays { get; set; }
    public DateTime? WorkTime { get; set; }
    public string EmployeeId { get; set; } = null!;
}

public class SalaryResponseDto
{
    public int? Id { get; set; }
    public decimal BasicSalary { get; set; }
    public int NumberOfDays { get; set; }
    public decimal? Allowance { get; set; }
    public DateTime? WorkTime { get; set; }
    public string EmployeeId { get; set; } = null!;
}
