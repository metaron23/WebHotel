using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO.RoomStarDtos;
using WebHotel.Repository.AdminRepository.RoomStarRepository;

namespace WebHotel.Controllers.UserController;

[ApiController]
[ApiVersion("1.0")]
public class RoomStarUserController : ControllerBase
{
    private readonly IRoomStarRepository _roomStarRepository;

    public RoomStarUserController(IRoomStarRepository roomStarRepository)
    {
        _roomStarRepository = roomStarRepository;
    }

    [HttpPost]
    [Route("user/room-star/create")]
    public async Task<IActionResult> Create(RoomStarRequestDto roomStarRequestDto)
    {
        var result = await _roomStarRepository.Create(roomStarRequestDto);
        if (result.StatusCode == 1)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
