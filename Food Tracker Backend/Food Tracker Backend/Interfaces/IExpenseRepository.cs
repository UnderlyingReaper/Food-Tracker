using Food_Tracker_Backend.Models;

namespace Food_Tracker_Backend.Interfaces
{
    public interface IExpenseRepository
    {
        public Task<List<Expense>> GetAll();
        public Task<Expense?> Get(int id);
        public Task<Expense> CreateExpense(Expense expense);
        public Task<Expense?> EditExpense(int id, Expense data);
        public Task<Expense?> DeleteExpense(int id);
    }
}
