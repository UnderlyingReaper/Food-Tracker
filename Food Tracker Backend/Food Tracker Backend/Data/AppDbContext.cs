using Food_Tracker_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Tracker_Backend.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


        public DbSet<Restaurant> Restaurants => Set<Restaurant>();
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<MenuItem>().Property(m => m.Price).HasConversion<double>();
        }
    }
}
