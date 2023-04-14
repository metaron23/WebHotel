namespace WebHotel.DTO.RoomDtos
{
    public class RoomSearchDto
    {
        public int MaxPerson { get; set; }

        public decimal MaxPrice { get; set; }

        public List<string>? ServiceAttachs { get; set; }
    }
}
