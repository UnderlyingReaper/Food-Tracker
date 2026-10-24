using Food_Tracker_Backend.Models;

namespace Food_Tracker_Backend.Mappers
{
    public static class ExpenseMapper
    {
        public static Expense MapToExpense(this DTOs.CreateExpenseDto dto)
        {
            return new Expense
            {
                Description = dto.Description,
                Category = dto.Category,
                Amount = dto.Amount,
                Date = dto.Date
            };
        }

        public static Expense MapToExpense(this DTOs.EditExpenseDto dto)
        {
            return new Expense
            {
                Description = dto.Description,
                Category = dto.Category,
                Amount = dto.Amount,
                Date = dto.Date
            };
        }
    }
}
