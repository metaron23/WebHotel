using System;
using System.Collections.Generic;

namespace WebHotel.DTO;

public partial class TokenInfoDto
{

    public string? Usename { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime RefreshTokenExpiry { get; set; }
}
