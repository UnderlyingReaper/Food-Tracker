using Food_Tracker_Backend.Data;
using Food_Tracker_Backend.Interfaces;
using Food_Tracker_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Tracker_Backend.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _database;

        public ExpenseRepository(AppDbContext database)
        {
            _database = database;
        }

        public async Task<List<Expense>> GetExpensesSinceAsync(DateTime startDate)
        {
            return await _database.Expenses.AsNoTracking()
                .Where(e => e.Date >= startDate)
                .OrderByDescending(e => e.Date)
                .ToListAsync();
        }
        public async Task<List<Expense>> GetAllAsync()
        {
            return await _database.Expenses.ToListAsync();
        }
        public async Task<Expense?> GetAsync(int id)
        {
            return await _database.Expenses.FindAsync(id);
        }

        public async Task<Expense> CreateExpenseAsync(Expense expense)
        {
            await _database.Expenses.AddAsync(expense);
            await _database.SaveChangesAsync();

            return expense;
        }

        public async Task<Expense?> EditExpenseAsync(int id, Expense data)
        {
            var expense = await _database.Expenses.FirstOrDefaultAsync(x => x.Id == id);
            if (expense == null) return null;

            expense.Description = data.Description;
            expense.Category = data.Category;
            expense.Amount = data.Amount;

            await _database.SaveChangesAsync();

            return expense;
        }

        public async Task<Expense?> DeleteExpenseAsync(int id)
        {
            var expense = await _database.Expenses.FirstOrDefaultAsync(x => x.Id == id);
            if (expense == null) return null;

            _database.Expenses.Remove(expense);
            await _database.SaveChangesAsync();

            return expense;
        }
    }
}
