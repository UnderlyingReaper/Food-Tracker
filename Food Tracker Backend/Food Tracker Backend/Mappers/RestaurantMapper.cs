using Food_Tracker_Backend.DTOs;
using Food_Tracker_Backend.Models;

namespace Food_Tracker_Backend.Mappers
{
    public static class RestaurantMapper
    {
        public static Restaurant CreateDTOToModel(this CreateRestaurantDTO res)
        {
            return new Restaurant
            {
                Id = 0,
                Name = res.Name,
                MenuItems = []
            };
        }

        public static Restaurant EditDTOToModel(this EditRestaurantDTO res)
        {
            return new Restaurant
            {
                Id = 0,
                Name = res.Name,
                MenuItems = []
            };
        }
    }
}
