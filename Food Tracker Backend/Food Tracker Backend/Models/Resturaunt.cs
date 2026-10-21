namespace Food_Tracker_Backend.Models
{
    public class Resturaunt
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<MenuItem> MenuItems { get; set; } = [];
    }
}
