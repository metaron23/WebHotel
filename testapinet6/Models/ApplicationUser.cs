using Microsoft.AspNetCore.Identity;
using WebHotel.Models;

namespace WebHotel.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? CMND { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<DiscountReservationDetail> DiscountReservationDetails { get; } = new List<DiscountReservationDetail>();

        public virtual ICollection<DiscountRoomDetail> DiscountRoomDetails { get; } = new List<DiscountRoomDetail>();

        public virtual ICollection<DiscountServiceDetail> DiscountServiceDetails { get; } = new List<DiscountServiceDetail>();

        public virtual ICollection<Discount> Discounts { get; } = new List<Discount>();

        public virtual ICollection<InvoiceReservation> InvoiceReservations { get; } = new List<InvoiceReservation>();

        public virtual ICollection<OrderService> OrderServices { get; } = new List<OrderService>();

        public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
    }
}
