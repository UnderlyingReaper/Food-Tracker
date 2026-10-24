using System.ComponentModel.DataAnnotations;

namespace Food_Tracker_Backend.DTOs
{
    public class CreateMenuItemDTO
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; } = string.Empty;

        public float Price { get; set; } = 0f;

        [Required(ErrorMessage = "Menu Item must belong to a Restaurant")]
        public int RestaurantId { get; set; }
    }

    public class EditMenuItemDTO
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; } = string.Empty;

        public float Price { get; set; } = 0f;
    }
}
