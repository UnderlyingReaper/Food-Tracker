using Food_Tracker_Backend.DTOs;
using Food_Tracker_Backend.Interfaces;
using Food_Tracker_Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Food_Tracker_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetController: ControllerBase
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetRepository budgetRepository, IBudgetService budgetService)
        {
            _budgetRepository = budgetRepository;
            _budgetService = budgetService;
        }


        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            var dashboard = await _budgetService.GetDashboardAsync();
            if (dashboard == null)
                return BadRequest("No Budget Exists.");

            return Ok(dashboard);
        }


        // CRUD Operations for BudgetConfig
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var budget = await _budgetRepository.GetBudgetAsync();
            if (budget == null)
                return NotFound("No Budget currently exists, Create one.");

            return Ok(budget);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBudgetDTO dto)
        {
            var newBudget = dto.MapToModel();

            var savedBudget = await _budgetRepository.CreateBudgetAsync(newBudget);

            return CreatedAtAction(nameof(Get), null, savedBudget);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, EditBudgetDTO dto)
        {
            var budget = dto.MapToModel();

            var updatedBudget = await _budgetRepository.UpdateBudgetAsync(id, budget);
            if (updatedBudget == null)
                return NotFound($"Budget with ID {id} does not exist.");

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var budget = await _budgetRepository.DeleteBudgetAsync(id);
            if (budget == null)
                return NotFound($"Budget with ID {id} does not exist.");

            return NoContent();
        }
    }
}
