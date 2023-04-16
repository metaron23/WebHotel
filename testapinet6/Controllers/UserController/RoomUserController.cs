using Microsoft.AspNetCore.Mvc;
using WebHotel.Repository.RoomRepository;

namespace WebHotel.Controllers
{
    [ApiController]
    public partial class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        [Route("/user/room/get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roomRepository.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("/user/room/get-by-id")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _roomRepository.GetById(id);
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
            var result = await _roomRepository.GetAllBy(checkIn, checkOut, price, typeRoomId, star, peopleNumber);
            return Ok(result);
        }

        [HttpGet]
        [Route("/user/search-room")]
        public async Task<IActionResult> GetRoomSearch()
        {
            var result = await _roomRepository.GetRoomSearch();
            return Ok(result);
        }
    }
}
