using System;
using System.Collections.Generic;

namespace WebHotel.Models;

public partial class ReservationStatus
{
    public int Id { get; set; }

    public int StatusNumber { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<ReservationStatusEvent> ReservationStatusEvents { get; } = new List<ReservationStatusEvent>();
}
