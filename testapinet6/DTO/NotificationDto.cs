namespace WebHotel.DTO
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool? Status { get; set; }
        public bool Link { get; set; }
    }
}
