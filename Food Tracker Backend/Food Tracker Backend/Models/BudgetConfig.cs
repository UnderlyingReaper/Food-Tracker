namespace Food_Tracker_Backend.Models
{
    public class BudgetConfig
    {
        public int Id { get; set; }
        public float MonthlyBudget { get; set; } = 0f;
        public float DailyBudget { get; set; } = 0f;

        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
