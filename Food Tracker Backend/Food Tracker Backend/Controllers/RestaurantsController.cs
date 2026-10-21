using Food_Tracker_Backend.Interfaces;
using Food_Tracker_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food_Tracker_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository _Restaurantrepo;

        public RestaurantsController(IRestaurantRepository rRepo)
        {
            _Restaurantrepo = rRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _Restaurantrepo.GetAllAsync());
        }

        [HttpGet("{id:int}", Name = nameof(Get))]
        public async Task<IActionResult> Get(int id)
        {
            var restaurant = await _Restaurantrepo.GetByIdAsync(id);
            if (restaurant == null)
                return NotFound($"Restaurant with ID {id} was not found.");

            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Restaurant data)
        {
            var restaurant = await _Restaurantrepo.CreateAsync(data);

            return CreatedAtRoute(nameof(Get), new { id = restaurant.Id }, restaurant);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Restaurant data)
        {
            var restaurant = await _Restaurantrepo.UpdateAsync(id, data);
            if (restaurant == null)
                return NotFound($"Restaurant with ID {id} was not found.");

            return Ok(restaurant);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var restaurant = await _Restaurantrepo.DeleteAsync(id);
            if (restaurant == null)
                return NotFound($"Restaurant with ID {id} was not found.");

            return NoContent();
        }
    }
}
