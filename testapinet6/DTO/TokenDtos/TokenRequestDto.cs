using System.ComponentModel.DataAnnotations;

namespace WebHotel.DTO.Token
{
    public class TokenRequestDto
    {
        [Required]
        public string? AccessToken { get; set; }
        [Required]
        public string? RefreshToken { get; set; }
    }
}
