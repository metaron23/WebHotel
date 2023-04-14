using System.ComponentModel.DataAnnotations;

namespace WebHotel.DTO.RoomDtos
{
    public class RoomCreateDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string RoomNumber { get; set; } = null!;

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; } = null!;

        public bool? IsActive { get; set; }

        public string? Description { get; set; }

        public decimal CurrentPrice { get; set; }

        public IFormFile? RoomPicture { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int PeopleNumber { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int NumberOfBed { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int RoomTypeId { get; set; }
    }
}
