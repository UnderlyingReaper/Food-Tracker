using Food_Tracker_Backend.Data;
using Food_Tracker_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food_Tracker_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly AppDbContext _database;

        public RestaurantsController(AppDbContext dbContext)
        {
            _database = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_database.Resturaunts.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var restaurant = _database.Resturaunts.FirstOrDefault(r => r.Id == id);

            if (restaurant == null)
                return NotFound($"Restaurant with ID {id} was not found.");

            return Ok(restaurant);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Restaurant data)
        {
            var restaurant = _database.Resturaunts.Find(id);
            if (restaurant == null)
                return NotFound($"Restaurant with ID {id} was not found.");

            restaurant.Name = data.Name;
            _database.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(Restaurant data)
        {
            var newRestaurant = new Restaurant { Name = data.Name };
            _database.Add(newRestaurant);
            _database.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = newRestaurant.Id });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var restaurant = _database.Resturaunts.Find(id);
            if (restaurant == null)
                return NotFound($"Restaurant with ID {id} was not found.");

            _database.Resturaunts.Remove(restaurant);
            _database.SaveChanges();

            return NoContent();
        }
    }
}
