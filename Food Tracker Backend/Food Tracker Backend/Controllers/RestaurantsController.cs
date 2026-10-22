using Food_Tracker_Backend.DTOs.Restaurant;
using Food_Tracker_Backend.Interfaces;
using Food_Tracker_Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Food_Tracker_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepo;

        public RestaurantsController(IRestaurantRepository rRepo)
        {
            _restaurantRepo = rRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _restaurantRepo.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var restaurant = await _restaurantRepo.GetByIdAsync(id);
            if (restaurant == null)
                return NotFound($"Restaurant with ID {id} was not found.");

            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRestaurantDTO dto)
        {
            var data = dto.CreateDTOToModel();
            var restaurant = await _restaurantRepo.CreateAsync(data);

            return CreatedAtAction(nameof(Get), new { id = restaurant.Id }, restaurant);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, EditRestaurantDTO dto)
        {
            var data = dto.EditDTOToModel();
            var restaurant = await _restaurantRepo.UpdateAsync(id, data);
            if (restaurant == null)
                return NotFound($"Restaurant with ID {id} was not found.");

            return Ok(restaurant);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var restaurant = await _restaurantRepo.DeleteAsync(id);
            if (restaurant == null)
                return NotFound($"Restaurant with ID {id} was not found.");

            return NoContent();
        }
    }
}
