using Food_Tracker_Backend.DTOs;
using Food_Tracker_Backend.Models;

namespace Food_Tracker_Backend.Mappers
{
    public static class MenuItemMapper
    {
        public static MenuItem CreateDTOToModel(this CreateMenuItemDTO dto)
        {
            return new MenuItem
            {
                Id = 0,
                Name = dto.Name,
                Price = dto.Price,
                RestaurantId = dto.RestaurantId
            };
        }

        public static MenuItem EditDTOToModel(this EditMenuItemDTO dto)
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
