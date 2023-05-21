using Database.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebHotel.Controllers.AdminController;

[ApiController]
[ApiVersion("2.0")]
[Route("v{version:apiVersion}/admin/invoid/")]
[Authorize(Roles = "Admin")]
public class InvoidController : ControllerBase
{
    private readonly MyDBContext _context;

    public InvoidController(MyDBContext context)
    {
        _context = context;
    }

    //[HttpGet("get-all")]
    //public async Task<IActionResult> GetAll()
    //{
    //    var invoid = _context.InvoiceReservations.
    //}
}
