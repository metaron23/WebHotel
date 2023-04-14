using WebHotel.Model;

namespace WebHotel.Models;

public partial class Reservation
{
    public string Id { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public float NumberOfDay { get; set; }

    public DateTime EndDate { get; set; }

    public decimal RoomPrice { get; set; }

    public DateTime? DepositEndAt { get; set; }

    public byte[]? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public decimal ReservationPrice { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string RoomId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public virtual ICollection<DiscountReservationDetail> DiscountReservationDetails { get; } = new List<DiscountReservationDetail>();

    public virtual ICollection<InvoiceReservation> InvoiceReservations { get; } = new List<InvoiceReservation>();

    public virtual ICollection<OrderService> OrderServices { get; } = new List<OrderService>();

    public virtual ICollection<ReservationChat> ReservationChats { get; } = new List<ReservationChat>();

    public virtual ICollection<ReservationStatusEvent> ReservationStatusEvents { get; } = new List<ReservationStatusEvent>();

    public virtual Room Room { get; set; } = null!;

    public virtual ApplicationUser User { get; set; } = null!;
}
