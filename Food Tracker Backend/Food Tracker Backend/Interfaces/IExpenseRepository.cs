using Food_Tracker_Backend.Models;

namespace Food_Tracker_Backend.Interfaces
{
    public interface IExpenseRepository
    {
        public Task<List<Expense>> GetExpensesSinceAsync(DateTime startDate);
        public Task<List<Expense>> GetAllAsync();
        public Task<Expense?> GetAsync(int id);
        public Task<Expense> CreateExpenseAsync(Expense expense);
        public Task<Expense?> EditExpenseAsync(int id, Expense data);
        public Task<Expense?> DeleteExpenseAsync(int id);
    }
}
