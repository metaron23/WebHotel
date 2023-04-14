using System;
using System.Collections.Generic;

namespace WebHotel.Models;

public partial class DiscountType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Discount> Discounts { get; } = new List<Discount>();
}
