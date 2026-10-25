using Food_Tracker_Backend.DTOs;
using Food_Tracker_Backend.Models;

namespace Food_Tracker_Backend.Mappers
{
    public static class MenuItemMapper
    {
        public static MenuItem MapToModel(this CreateMenuItemDTO dto)
        {
            return new MenuItem
            {
                Id = 0,
                Name = dto.Name,
                Price = dto.Price,
                RestaurantId = dto.RestaurantId
            };
        }

        public static MenuItem MapToModel(this EditMenuItemDTO dto)
        {
            return new MenuItem
            {
                Id = 0,
                Name = dto.Name,
                Price = dto.Price
            };
        }
    }
}
