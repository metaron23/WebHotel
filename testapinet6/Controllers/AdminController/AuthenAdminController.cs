using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO;
using WebHotel.DTO.AuthenticationDtos;
using WebHotel.Repository.AdminRepository.AuthenRepository;

namespace WebHotel.Controllers.AdminController
{

    [ApiController]
    [Route("v{version:apiVersion}/admin/")]
    [ApiVersion("2.0")]
    public class AuthenAdminController : ControllerBase
    {
        private readonly IAuthenAdminRepository _authenAdminRepository;

        public AuthenAdminController(IAuthenAdminRepository authenAdminRepository)
        {
            _authenAdminRepository = authenAdminRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login123([FromBody] LoginDto model)
        {
            var result = await _authenAdminRepository.Login(model);
            if (result is LoginResponseDto)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegistrationAdmin([FromBody] RegisterAdminDto model)
        {
            StatusDto result = await _authenAdminRepository.RegistrationAdmin(model);
            if (result.StatusCode == 1)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
