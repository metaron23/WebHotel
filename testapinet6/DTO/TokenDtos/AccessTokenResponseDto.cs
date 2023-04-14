namespace WebHotel.DTO.Token
{
    public class AccessTokenResponseDto
    {
        public string? TokenString { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
