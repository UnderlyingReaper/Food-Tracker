using System.ComponentModel.DataAnnotations;

namespace Food_Tracker_Backend.DTOs
{
    public class CreateRestaurantDTO
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; } = String.Empty;
    }

    public class EditRestaurantDTO
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; } = String.Empty;
    }
}
