namespace WebHotel.DTO.DiscountDtos
{
    public class DiscountRequestDto
    {
        public string Name { get; set; } = null!;

        public decimal DiscountPercent { get; set; }

        public int AmountUse { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        public bool? IsPermanent { get; set; }

        public int DiscountTypeId { get; set; }
    }
}
