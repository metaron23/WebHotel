using System;
using System.Collections.Generic;

namespace WebHotel.Models;

public partial class RoomType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();

    public virtual ICollection<ServiceAttachDetail> ServiceAttachDetails { get; } = new List<ServiceAttachDetail>();
}
