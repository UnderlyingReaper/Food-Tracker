using Food_Tracker_Backend.Models;

namespace Food_Tracker_Backend.Interfaces
{
    public interface IMenuItemRepository
    {
        public Task<bool> MenuItemExistsAsync(int id);

        public Task<List<MenuItem>> GetAllAsync();
        public Task<MenuItem?> GetByIdAsync(int id);
        public Task<MenuItem> CreateAsync(MenuItem data);
        public Task<MenuItem?> UpdateAsync(int id, MenuItem data);
        public Task<MenuItem?> DeleteAsync(int id);
    }
}
