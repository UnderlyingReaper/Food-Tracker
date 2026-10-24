using Food_Tracker_Backend.DTOs;
using Food_Tracker_Backend.Models;

namespace Food_Tracker_Backend.Mappers
{
    public static class BudgetMapper
    {
        public static BudgetConfig CreateDTOToModel(this CreateBudgetDTO dto)
        {
            return new BudgetConfig
            {
                Id = 0,
                MonthlyBudget = dto.MonthlyBudget,
                DailyBudget = dto.DailyBudget,
                LastUpdated = DateTime.Now
            };
        }

        public static BudgetConfig EditDTOToModel(this EditBudgetDTO dto)
        {
            return new BudgetConfig
            {
                Id = 0,
                MonthlyBudget = dto.MonthlyBudget,
                DailyBudget = dto.DailyBudget,
                LastUpdated = DateTime.Now
            };
        }
    }
}
