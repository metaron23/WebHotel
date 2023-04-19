using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO.RoomTypeDtos;
using WebHotel.Repository.AdminRepository.RoomTypeRepository;

namespace WebHotel.Controllers.AdminController;

[ApiController]
[ApiVersion("2.0")]
public class RoomTypeAdminController : ControllerBase
{
    private readonly IRoomTypeRepository _roomTypeRepository;

    public RoomTypeAdminController(IRoomTypeRepository roomTypeRepository)
    {
        _roomTypeRepository = roomTypeRepository;
    }

    [HttpGet]
    [Route("admin/room-type/get")]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<RoomTypeController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost]
    [Route("admin/room-type/create")]
    public async Task<IActionResult> Create([FromBody] RoomTypeRequestDto roomTypeCreateDto)
    {
        var result = await _roomTypeRepository.Create(roomTypeCreateDto);
        if (result.StatusCode == 1)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    // PUT api/<RoomTypeController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<RoomTypeController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
