﻿using Microsoft.AspNetCore.Identity;
using WebHotel.Models;

namespace WebHotel.Model
{
    public class ApplicationUser : IdentityUser<string>
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

        public virtual ICollection<ApplicationUserClaim> Claims { get; } = new List<ApplicationUserClaim>();
        public virtual ICollection<ApplicationUserLogin> Logins { get; } = new List<ApplicationUserLogin>();
        public virtual ICollection<ApplicationUserToken> Tokens { get; } = new List<ApplicationUserToken>();
        public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }

    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() : base()
        {
        }
        public ApplicationRole(string roleName) : base(roleName)
        {
        }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; } = new List<ApplicationRoleClaim>();
    }

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser? User { get; set; }
        public virtual ApplicationRole? Role { get; set; }
    }

    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual ApplicationUser? User { get; set; }
    }

    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        public virtual ApplicationUser? User { get; set; }
    }

    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public virtual ApplicationRole? Role { get; set; }
    }

    public class ApplicationUserToken : IdentityUserToken<string>
    {
        public virtual ApplicationUser? User { get; set; }
    }
}
