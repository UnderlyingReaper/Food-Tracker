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

        public async Task<List<Expense>> GetAll()
        {
            return await _database.Expenses.ToListAsync();
        }
        public async Task<Expense?> Get(int id)
        {
            return await _database.Expenses.FindAsync(id);
        }

        public async Task<Expense> CreateExpense(Expense expense)
        {
            await _database.Expenses.AddAsync(expense);
            await _database.SaveChangesAsync();

            return expense;
        }

        public async Task<Expense?> EditExpense(int id, Expense data)
        {
            var expense = await _database.Expenses.FirstOrDefaultAsync(x => x.Id == id);
            if (expense == null) return null;

            expense.Description = data.Description;
            expense.Category = data.Category;
            expense.Amount = data.Amount;

            await _database.SaveChangesAsync();

            return expense;
        }

        public async Task<Expense?> DeleteExpense(int id)
        {
            var expense = await _database.Expenses.FirstOrDefaultAsync(x => x.Id == id);
            if (expense == null) return null;

            _database.Expenses.Remove(expense);
            await _database.SaveChangesAsync();

            return expense;
        }
    }
}
