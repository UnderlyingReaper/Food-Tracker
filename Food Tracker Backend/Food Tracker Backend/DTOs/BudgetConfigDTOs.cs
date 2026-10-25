using System.ComponentModel.DataAnnotations;

namespace Food_Tracker_Backend.DTOs
{
    public class CreateBudgetDTO
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "Monthly Budget must be greater than 0.")]
        public float MonthlyBudget { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Daily Budget must be greater than 0.")]
        public float DailyBudget { get; set; }
    }

    public class EditBudgetDTO
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "Monthly Budget must be greater than 0.")]
        public float MonthlyBudget { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Daily Budget must be greater than 0.")]
        public float DailyBudget { get; set; }

        [Required(ErrorMessage = "Updated date is required.")]
        public DateTime Updated { get; set; }
    }

    public class BudgetDashboardDTO
    {
        public float MonthlyBudget { get; set; }
        public float SpentThisMonth { get; set; }
        public float RemainingThisMonth { get; set; }

        public float FixedDailyBudget { get; set; }
        public float DynamicDailyBudget { get; set; }

        public float SpentToday { get; set; }

        public float FixedRemainingToday { get; set; }
        public float DynamicRemainingToday { get; set; }
    }
}
