using Food_Tracker_Backend.Data;
using Food_Tracker_Backend.Interfaces;
using Food_Tracker_Backend.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Food_Tracker_Backend.Repositories
{
    public class RestaurantRepository: IRestaurantRepository
    {
        private readonly AppDbContext _database;

        public RestaurantRepository(AppDbContext dbContext)
        {
            _database = dbContext;
        }

        public async Task<bool> RestaurnatExistsAsync(int id)
        {
            return await _database.Restaurants.AnyAsync(r => r.Id == id);
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            return await _database.Restaurants.AsNoTracking().ToListAsync();
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            return await _database.Restaurants.FindAsync(id);
        }

        public async Task<Restaurant> CreateAsync(Restaurant data)
        {
            await _database.AddAsync(data);
            await _database.SaveChangesAsync();

            return data;
        }

        public async Task<Restaurant?> UpdateAsync(int id, Restaurant data)
        {
            var restaurant = await _database.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
            if (restaurant == null) return null;

            restaurant.Name = data.Name;

            await _database.SaveChangesAsync();

            return restaurant;
        }

        public async Task<Restaurant?> DeleteAsync(int id)
        {
            var restaurant = await _database.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
            if (restaurant == null) return null;

            _database.Remove(restaurant);
            await _database.SaveChangesAsync();

            return restaurant;
        }
    }
}
