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
        private readonly IBudgetConfigRepository _budgetRepository;

        public BudgetController(IBudgetConfigRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var budget = await _budgetRepository.GetBudget();
            if (budget == null)
                return NotFound("No Budget currently exists, Create one.");

            return Ok(budget);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBudgetDTO dto)
        {
            var newBudget = dto.CreateDTOToModel();

            var savedBudget = await _budgetRepository.CreateBudget(newBudget);

            return CreatedAtAction(nameof(Get), new { id = savedBudget.Id }, savedBudget);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, EditBudgetDTO dto)
        {
            var budget = dto.EditDTOToModel();

            var updatedBudget = await _budgetRepository.UpdateBudget(id, budget);
            if (updatedBudget == null)
                return NotFound($"Budget with ID {id} does not exist.");

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var budget = await _budgetRepository.DeleteBudget(id);
            if (budget == null)
                return NotFound($"Budget with ID {id} does not exist.");

            return NoContent();
        }
    }
}
