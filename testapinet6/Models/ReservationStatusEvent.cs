using System;
using System.Collections.Generic;

namespace WebHotel.Models;

public partial class ReservationStatusEvent
{
    public int Id { get; set; }

    public DateTime? CreateAt { get; set; }

    public string ReservationId { get; set; } = null!;

    public int ReservationStatusId { get; set; }

    public virtual Reservation Reservation { get; set; } = null!;

    public virtual ReservationStatus ReservationStatus { get; set; } = null!;
}
