using Database.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebHotel.Controllers.AdminController;

[ApiController]
[ApiVersion("2.0")]
[Route("v{version:apiVersion}/admin/revenue/")]
//[Authorize]
public class RevenueAdminController : ControllerBase
{
    private readonly MyDBContext _context;

    public RevenueAdminController(MyDBContext context)
    {
        _context = context;
    }

    [HttpGet("get-sum")]
    public async Task<IActionResult> GetSum()
    {
        var customerIds = await _context.ApplicationUserRoles
            .Include(a => a.Role)
            .Where(a => a.Role!.Name == "User")
            .Select(a => a.UserId)
            .Distinct()
            .ToListAsync();

        var sumCustomer = await _context.ApplicationUsers
            .Where(a => customerIds.Contains(a.Id))
            .GroupBy(a => a.CreatedAt!.Value.Year)
            .Select(a => new { Year = a.Key, Count = a.Count() })
            .ToListAsync();

        var sumReservation = await _context.InvoiceReservations
            .GroupBy(a => a.PayAt.Year)
            .Select(a => new { Year = a.Key, Count = a.Count() })
            .ToListAsync();

        var sumRevenue = await _context.InvoiceReservations
            .GroupBy(a => a.PayAt.Year)
            .Select(
                a => new { Year = a.Key, Sum = a.Sum(a => (a.PriceService + a.PriceReservedRoom)) }
            )
            .ToListAsync();

        var years = sumCustomer.Select(a => a.Year).ToList();
        var results = new List<object>();
        years.ForEach(a =>
        {
            var result = new
            {
                Year = a,
                Result = new Revenue
                {
                    SumCustomer = sumCustomer.Where(b => b.Year == a).Select(b => b.Count),
                    SumReservation = sumReservation.Where(b => b.Year == a).Select(b => b.Count),
                    SumRevenue = sumRevenue.Where(b => b.Year == a).Select(b => b.Sum)
                }
            };
            results.Add(result);
        });

        return Ok(results);
    }

    [HttpGet("revenue-by-year")]
    public async Task<IActionResult> RevenueByYear()
    {
        var result = await _context.InvoiceReservations
            .GroupBy(a => a.PayAt.Month)
            .Select(
                a =>
                    new
                    {
                        Month = a.Key,
                        Revenue = a.Sum(a => (a.PriceReservedRoom + a.PriceService))
                    }
            )
            .ToListAsync();
        return Ok(result);
    }

    [HttpGet("revenue-by-month")]
    public async Task<IActionResult> RevenueByMonth()
    {
        var result = await _context.InvoiceReservations
            .GroupBy(a => a.PayAt.Day)
            .Select(
                a =>
                    new
                    {
                        Day = a.Key,
                        Revenue = a.Sum(a => (a.PriceReservedRoom + a.PriceService))
                    }
            )
            .ToListAsync();
        return Ok(result);
    }
}

public class Revenue
{
    public object SumCustomer { get; set; } = null!;
    public object SumReservation { get; set; } = null!;
    public object SumRevenue { get; set; } = null!;
}
