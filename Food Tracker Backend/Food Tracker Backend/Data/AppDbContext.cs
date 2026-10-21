using Food_Tracker_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Tracker_Backend.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


        public DbSet<Resturaunt> Resturaunts => Set<Resturaunt>();
        public DbSet<MenuItem> MenuItem => Set<MenuItem>();


    }
}
