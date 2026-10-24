namespace Food_Tracker_Backend.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public float Amount { get; set; } = 0f;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
