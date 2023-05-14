namespace Database.Models;

public partial class InvoiceReservation
{
    public int Id { get; set; }

    public DateTime PayAt { get; set; }

    public decimal? PriceService { get; set; }

    public decimal PriceReservedRoom { get; set; }

    public string ReservationId { get; set; } = null!;

    public virtual Reservation Reservation { get; set; } = null!;
}
