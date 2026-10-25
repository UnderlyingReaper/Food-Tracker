using Food_Tracker_Backend.Models;

namespace Food_Tracker_Backend.Interfaces
{
    public interface IBudgetRepository
    {
        public Task<BudgetConfig?> GetBudgetAsync();
        public Task<bool> BudgetExistsAsync(int id);
        public Task<BudgetConfig> CreateBudgetAsync(BudgetConfig data);
        public Task<BudgetConfig?> UpdateBudgetAsync(int id, BudgetConfig data);
        public Task<BudgetConfig?> DeleteBudgetAsync(int id);
    }
}
