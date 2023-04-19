using Microsoft.AspNetCore.Mvc;
using WebHotel.Repository.UserRepository.RoomUserRepository;

namespace WebHotel.Controllers.UserController;

[ApiController]
[ApiVersion("1.0")]
public partial class RoomUserController : ControllerBase
{
    private readonly IRoomUserRepository _roomUserRepository;
    public RoomUserController(IRoomUserRepository roomUserRepository)
    {
        _roomUserRepository = roomUserRepository;
    }

    [HttpGet]
    [Route("/user/room/get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _roomUserRepository.GetAll();
        return Ok(result);
    }

    [HttpGet]
    [Route("/user/room/get-by-id")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _roomUserRepository.GetById(id);
        if (result is not null)
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [HttpGet]
    [Route("/user/room/get-all-by")]
    public async Task<IActionResult> GetAllBy(DateTime? checkIn, DateTime? checkOut, decimal? price, int? typeRoomId, float? star, int? peopleNumber)
    {
        var result = await _roomUserRepository.GetAllBy(checkIn, checkOut, price, typeRoomId, star, peopleNumber);
        return Ok(result);
    }

    [HttpGet]
    [Route("/user/search-room")]
    public async Task<IActionResult> GetRoomSearch()
    {
        var result = await _roomUserRepository.GetRoomSearch();
        return Ok(result);
    }
}
