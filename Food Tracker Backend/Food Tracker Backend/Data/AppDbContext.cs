using Food_Tracker_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Tracker_Backend.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


        public DbSet<Restaurant> Restaurants => Set<Restaurant>();
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
        public DbSet<BudgetConfig> Budgets => Set<BudgetConfig>();
        public DbSet<Expense> Expenses => Set<Expense>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<MenuItem>().Property(m => m.Price).HasConversion<double>();

            b.Entity<BudgetConfig>().Property(m => m.DailyBudget).HasConversion<double>();
            b.Entity<BudgetConfig>().Property(m => m.MonthlyBudget).HasConversion<double>();

            b.Entity<Expense>().Property(m => m.Amount).HasConversion<double>();
        }
    }
}
