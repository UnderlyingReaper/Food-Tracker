using Food_Tracker_Backend.Data;
using Food_Tracker_Backend.Interfaces;
using Food_Tracker_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Tracker_Backend.Repositories
{
    public class BudgetRepository: IBudgetRepository
    {
        private readonly AppDbContext _database;

        public BudgetRepository(AppDbContext database)
        {
            _database = database;
        }

        public async Task<BudgetConfig?> GetBudgetAsync()
        {
            return await _database.Budgets.FirstOrDefaultAsync();
        }

        public async Task<bool> BudgetExistsAsync(int id)
        {
            return await _database.Budgets.AnyAsync(budget => budget.Id == id);
        }

        public async Task<BudgetConfig> CreateBudgetAsync(BudgetConfig data)
        {
            await _database.AddAsync(data);
            await _database.SaveChangesAsync();

            return data;
        }

        public async Task<BudgetConfig?> UpdateBudgetAsync(int id, BudgetConfig data)
        {
            var budget = await _database.Budgets.FirstOrDefaultAsync(budget => budget.Id == id);
            if (budget == null) return null;

            budget.MonthlyBudget = data.MonthlyBudget;
            budget.DailyBudget = data.DailyBudget;
            budget.LastUpdated = data.LastUpdated;

            await _database.SaveChangesAsync();

            return budget;
        }

        public async Task<BudgetConfig?> DeleteBudgetAsync(int id)
        {
            var budget = await _database.Budgets.FirstOrDefaultAsync(b => b.Id == id);
            if (budget == null) return null;

            _database.Remove(budget);
            await _database.SaveChangesAsync();

            return budget;
        }
    }
}
