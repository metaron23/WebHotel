using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO.RoomDtos;

namespace WebHotel.Controllers
{
    public partial class RoomController
    {

        [HttpPost]
        [Route("/room/create")]
        public async Task<IActionResult> Create([FromForm] RoomCreateDto roomCreateDto)
        {
            var result = await _roomRepository.Create(roomCreateDto)!;
            if (result.StatusCode == 1)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
