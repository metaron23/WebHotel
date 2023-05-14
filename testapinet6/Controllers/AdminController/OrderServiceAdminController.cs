﻿using AutoMapper;
using Database.Data;
using Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using WebHotel.DTO;

namespace WebHotel.Controllers.AdminController;

[ApiController]
[ApiVersion("2.0")]
[Route("v{version:apiVersion}/admin/order-service/")]
[Authorize(Roles = "Admin")]
public class OrderServiceAdminController : ControllerBase
{
    private readonly MyDBContext _context;
    private readonly IMapper _mapper;

    public OrderServiceAdminController(MyDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(OrderServiceCreateDto orderServiceCreate)
    {
        var service = await _context.ServiceRooms.AsNoTracking().SingleOrDefaultAsync(a => a.Id == orderServiceCreate.ServiceRoomId);
        var user = User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email)!.Value;
        var creator = await _context.ApplicationUsers.AsNoTracking().SingleOrDefaultAsync(a => a.Email == user);
        if (service is null)
        {
            return BadRequest(new StatusDto { StatusCode = 0, Message = "Service room id not found" });
        }
        var orderService = new OrderService()
        {
            Amount = orderServiceCreate.Amount,
            Price = service.Price,
            ServiceName = service.Name,
            ReservationId = orderServiceCreate.ReservationId,
            ServiceRoomId = service.Id,
            UserId = creator!.Id
        };
        await _context.AddAsync(orderService);
        service.Amount -= orderService.Amount;
        await _context.SaveChangesAsync();
        return Ok(new StatusDto { StatusCode = 1, Message = "Created successfully" });
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = _mapper.Map<List<OrderServiceResponseDto>>(await _context.OrderServices.AsNoTracking().Include(a => a.User).ToListAsync());
        if (result.Count == 0)
        {
            return NotFound();
        }
        return Ok(result);
    }
}
public class OrderServiceCreateDto
{
    [Required(ErrorMessage = "{0} is required")]
    public int Amount { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public int ServiceRoomId { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public string ReservationId { get; set; } = null!;
}

public class OrderServiceResponseDto
{
    public int Id { get; set; }

    public string ServiceName { get; set; } = null!;

    public decimal Price { get; set; }

    public int Amount { get; set; }

    public string CreatorEmail { get; set; } = null!;

    public string ReservationId { get; set; } = null!;
}
