using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO;
using WebHotel.DTO.RoomTypeDtos;
using WebHotel.Repository.AdminRepository.RoomTypeRepository;

namespace WebHotel.Controllers.AdminController;

[ApiController]
[ApiVersion("2.0")]
[Route("v{version:apiVersion}/admin/room-type/")]
public class RoomTypeAdminController : ControllerBase
{
    private readonly IRoomTypeRepository _roomTypeRepository;

    public RoomTypeAdminController(IRoomTypeRepository roomTypeRepository)
    {
        _roomTypeRepository = roomTypeRepository;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] RoomTypeRequestDto roomTypeCreateDto)
    {
        var result = await _roomTypeRepository.Create(roomTypeCreateDto);
        if (result.StatusCode == 1)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> Update([FromQuery] int? id, [FromBody] RoomTypeRequestDto roomTypeRequestDto)
    {
        var result = await _roomTypeRepository.Update(id, roomTypeRequestDto);
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
        var result = await _roomTypeRepository.GetAll();
        if (result is null)
        {
            return NotFound(result);
        }
        return Ok(result);
    }

    [HttpGet]
    [Route("delete")]
    public async Task<StatusDto> Delete([FromQuery] int? id)
    {
        return await _roomTypeRepository.Delete(id);
    }
}
