namespace WebHotel.Models;

public partial class Room
{
    public string Id { get; set; } = null!;

    public string RoomNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? Description { get; set; }

    public string? RoomPicture { get; set; }

    public int? StarSum { get; set; }

    public int PeopleNumber { get; set; }

    public int NumberOfBed { get; set; }

    public decimal CurrentPrice { get; set; }

    public decimal? DiscountPrice { get; set; }

    public DateTime? CreatedAt { get; set; }

    public byte[]? UpdatedAt { get; set; }

    public int RoomTypeId { get; set; }

    public int? StarAmount { get; set; }

    public int? StarValue { get; set; }

    public virtual ICollection<DiscountRoomDetail> DiscountRoomDetails { get; } = new List<DiscountRoomDetail>();

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();

    public virtual ICollection<RoomStar> RoomStars { get; } = new List<RoomStar>();

    public virtual RoomType RoomType { get; set; } = null!;
}
