using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO.RoomDtos;
using WebHotel.Repository.AdminRepository.RoomRepository;

namespace WebHotel.Controllers;

[ApiController]
[ApiVersion("2.0")]
public partial class RoomAdminController : ControllerBase
{
    private readonly IRoomAdminRepository _roomAdminRepository;
    public RoomAdminController(IRoomAdminRepository roomAdminRepository)
    {
        _roomAdminRepository = roomAdminRepository;
    }

    [HttpPost]
    [Route("/admin/room/create")]
    public async Task<IActionResult> Create([FromForm] RoomRequestDto roomCreateDto)
    {
        var result = await _roomAdminRepository.Create(roomCreateDto)!;
        if (result.StatusCode == 1)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
