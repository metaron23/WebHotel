using WebHotel.Model;

namespace WebHotel.Models;

public partial class InvoiceReservation
{
    public int Id { get; set; }

    public DateTime IssuedAt { get; set; }

    public byte[]? PaidAt { get; set; }

    public decimal? PriceService { get; set; }

    public decimal PriceReservedRoom { get; set; }

    public string ReservationId { get; set; } = null!;

    public string ConfirmerId { get; set; } = null!;

    public virtual ApplicationUser Confirmer { get; set; } = null!;

    public virtual Reservation Reservation { get; set; } = null!;
}
