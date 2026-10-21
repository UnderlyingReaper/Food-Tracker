using Food_Tracker_Backend.Models;

namespace Food_Tracker_Backend.Interfaces
{
    public interface IRestaurantRepository
    {
        public Task<bool> RestaurnatExistsAsync(int id);

        public Task<List<Restaurant>> GetAllAsync();
        public Task<Restaurant?> GetByIdAsync(int id);
        public Task<Restaurant> CreateAsync(Restaurant data);
        public Task<Restaurant?> UpdateAsync(int id, Restaurant data);
        public Task<Restaurant?> DeleteAsync(int id);
    }
}
