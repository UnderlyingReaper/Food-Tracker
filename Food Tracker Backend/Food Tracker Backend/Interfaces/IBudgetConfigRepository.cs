using Food_Tracker_Backend.Models;

namespace Food_Tracker_Backend.Interfaces
{
    public interface IBudgetConfigRepository
    {
        public Task<BudgetConfig?> GetBudget();
        public Task<bool> BudgetExists(int id);
        public Task<BudgetConfig> CreateBudget(BudgetConfig data);
        public Task<BudgetConfig?> UpdateBudget(int id, BudgetConfig data);
        public Task<BudgetConfig?> DeleteBudget(int id);
    }
}
