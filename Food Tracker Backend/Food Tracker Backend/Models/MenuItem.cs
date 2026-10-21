namespace Food_Tracker_Backend.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }

        public int ResturauntId { get; set; }
        public Resturaunt? Resturaunt { get; set; }
    }
}
