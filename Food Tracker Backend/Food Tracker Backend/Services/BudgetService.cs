using Food_Tracker_Backend.DTOs;
using Food_Tracker_Backend.Interfaces;

namespace Food_Tracker_Backend.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IExpenseRepository _expenseRepository;

        public BudgetService(IBudgetRepository budgetRepository, IExpenseRepository expenseRepository)
        {
            _budgetRepository = budgetRepository;
            _expenseRepository = expenseRepository;
        }

        public async Task<BudgetDashboardDTO> GetDashboardAsync()
        {
            var budget = await _budgetRepository.GetBudgetAsync();
            if (budget == null)
                return null;

            var expenses = await _expenseRepository.GetExpensesSinceAsync(budget.LastUpdated.Date);

            // Monthly
            float spentThisMonth = expenses.Sum(e => e.Amount);
            float remainingThisMonth = budget.MonthlyBudget - spentThisMonth;

            // Daily
            float spentToday = expenses.Where(e => e.Date.Date == DateTime.Today).Sum(e => e.Amount);

            float fixedRemainingToday = budget.DailyBudget - spentToday;

            int totalMonthDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int daysPassed = (DateTime.Today - budget.LastUpdated.Date).Days;
            int remainingDays = Math.Max(1, totalMonthDays - daysPassed);

            float dynamicDailyBudget = remainingThisMonth / remainingDays;
            float dynamicRemainingToday = dynamicDailyBudget - spentToday;

            return new BudgetDashboardDTO
            {
                MonthlyBudget = budget.MonthlyBudget,
                SpentThisMonth = spentThisMonth,
                RemainingThisMonth = remainingThisMonth,

                FixedDailyBudget = budget.DailyBudget,
                DynamicDailyBudget = dynamicDailyBudget,

                SpentToday = spentToday,

                FixedRemainingToday = fixedRemainingToday,
                DynamicRemainingToday = dynamicRemainingToday
            };
        }
    }
}
