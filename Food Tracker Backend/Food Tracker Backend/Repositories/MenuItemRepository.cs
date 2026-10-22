using Food_Tracker_Backend.Data;
using Food_Tracker_Backend.Interfaces;
using Food_Tracker_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Tracker_Backend.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly AppDbContext _database;

        public MenuItemRepository(AppDbContext db)
        {
            _database = db;
        }

        public async Task<MenuItem> CreateAsync(MenuItem data)
        {
            await _database.MenuItems.AddAsync(data);
            await _database.SaveChangesAsync();

            return data;
        }

        public async Task<MenuItem?> DeleteAsync(int id)
        {
            var menuItem = await _database.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
            if (menuItem == null) return null;

            _database.MenuItems.Remove(menuItem);
            await _database.SaveChangesAsync();

            return menuItem;
        }

        public async Task<List<MenuItem>> GetAllAsync()
        {
            return await _database.MenuItems.AsNoTracking().ToListAsync();
        }

        public async Task<MenuItem?> GetByIdAsync(int id)
        {
            return await _database.MenuItems.FindAsync(id);
        }

        public async Task<bool> MenuItemExistsAsync(int id)
        {
            return await _database.MenuItems.AnyAsync(m => m.Id == id);
        }

        public async Task<MenuItem?> UpdateAsync(int id, MenuItem data)
        {
            var menuItem = await _database.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
            if (menuItem == null) return null;

            menuItem.RestaurantId = id;
            menuItem.Name = data.Name;
            menuItem.Price = data.Price;
            await _database.SaveChangesAsync();

            return menuItem;
        }
    }
}
