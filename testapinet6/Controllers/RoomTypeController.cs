using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO.RoomTypeDtos;
using WebHotel.Repository.RoomTypeRepository;

namespace WebHotel.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeController(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        [HttpGet]
        [Route("/room-type/get")]
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
        [Route("/room-type/create")]
        public async Task<IActionResult> Create([FromBody] RoomTypeCreateDto roomTypeCreateDto)
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
}
