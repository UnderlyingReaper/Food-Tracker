using Food_Tracker_Backend.DTOs.Menu_Item;
using Food_Tracker_Backend.Interfaces;
using Food_Tracker_Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Food_Tracker_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemRepository _menuItemRepo;

        public MenuItemController(IMenuItemRepository mRepo)
        {
            _menuItemRepo = mRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _menuItemRepo.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var menuItem = await _menuItemRepo.GetByIdAsync(id);
            if (menuItem == null)
                return NotFound($"Menu Item with ID {id} was not found.");

            return Ok(menuItem);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuItemDTO dto)
        {
            var data = dto.CreateDTOToModel();
            var menuItem = await _menuItemRepo.CreateAsync(data);

            return CreatedAtAction(nameof(Get), new { id = menuItem.Id }, menuItem);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, EditMenuItemDTO dto)
        {
            var data = dto.EditDTOToModel();
            var restaurant = await _menuItemRepo.UpdateAsync(id, data);
            if (restaurant == null)
                return NotFound($"Menu Item with ID {id} was not found.");

            return Ok(restaurant);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var menuItem = await _menuItemRepo.DeleteAsync(id);
            if (menuItem == null)
                return NotFound($"Menu Item with ID {id} was not found.");

            return NoContent();
        }
    }
}
