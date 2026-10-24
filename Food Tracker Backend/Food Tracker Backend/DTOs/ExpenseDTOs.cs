using System.ComponentModel.DataAnnotations;

namespace Food_Tracker_Backend.DTOs
{
    public class CreateExpenseDto
    {
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; } = string.Empty;

        [Range(0.01, float.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public float Amount { get; set; } = 0f;

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; } = DateTime.Now;
    }

    public class EditExpenseDto
    {
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; } = string.Empty;

        [Range(0.01, float.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public float Amount { get; set; } = 0f;

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
