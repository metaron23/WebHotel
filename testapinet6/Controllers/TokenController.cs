using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO;
using WebHotel.DTO.Token;
using WebHotel.Service.TokenRepository;

namespace WebHotel.Controllers
{
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenRepository _service;

        public TokenController(ITokenRepository service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("user/token/refresh")]
        public IActionResult Refresh(TokenRequestDto tokenRequest)
        {
            var token = _service.RefreshToken(tokenRequest);
            if (token is StatusDto)
            {
                return BadRequest(token);
            }
            return Ok(token);
        }

        [HttpPost]
        [Route("user/token/revoke")]
        public IActionResult Revoke(TokenRequestDto tokenRequest)
        {
            bool check = _service.Revoke(tokenRequest);
            if (!check)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
