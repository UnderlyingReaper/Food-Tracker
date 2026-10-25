using Food_Tracker_Backend.DTOs;
using Food_Tracker_Backend.Models;

namespace Food_Tracker_Backend.Mappers
{
    public static class BudgetMapper
    {
        public static BudgetConfig MapToModel(this CreateBudgetDTO dto)
        {
            return new BudgetConfig
            {
                Id = 0,
                MonthlyBudget = dto.MonthlyBudget,
                DailyBudget = dto.DailyBudget,
                LastUpdated = DateTime.Now
            };
        }

        public static BudgetConfig MapToModel(this EditBudgetDTO dto)
        {
            return new BudgetConfig
            {
                Id = 0,
                MonthlyBudget = dto.MonthlyBudget,
                DailyBudget = dto.DailyBudget,
                LastUpdated = DateTime.Now
            };
        }

        public static BudgetDashboardDTO MapToDashboard(this BudgetConfig budget)
        {
            return new BudgetDashboardDTO
            {
                MonthlyBudget = budget.MonthlyBudget,
                FixedDailyBudget = budget.DailyBudget,
                DynamicDailyBudget = 0,

                SpentThisMonth = 0,
                SpentToday = 0,

                RemainingThisMonth = 0,
                FixedRemainingToday = 0,
                DynamicRemainingToday = 0
            };
        }
    }
}
