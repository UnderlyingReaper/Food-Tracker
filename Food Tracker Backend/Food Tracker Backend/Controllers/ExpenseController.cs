using Food_Tracker_Backend.DTOs;
using Food_Tracker_Backend.Interfaces;
using Food_Tracker_Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Food_Tracker_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController: ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var expenses = await _expenseRepository.GetAll();
            return Ok(expenses);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var expense = await _expenseRepository.Get(id);
            if (expense == null)
                return NotFound($"Expense with ID: {id} not found.");

            return Ok(expense);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(CreateExpenseDto dto)
        {
            var expense = dto.MapToExpense();
            var createdExpense = await _expenseRepository.CreateExpense(expense);

            return CreatedAtAction(nameof(Get), new { id = createdExpense.Id }, createdExpense);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditExpense(int id, EditExpenseDto dto)
        {
            var expense = dto.MapToExpense();

            var updatedExpense = await _expenseRepository.EditExpense(id, expense);
            if (updatedExpense == null)
                return NotFound($"Expense with ID: {id} not found.");

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var deletedExpense = await _expenseRepository.DeleteExpense(id);
            if (deletedExpense == null)
                return NotFound($"Expense with ID: {id} not found.");

            return NoContent();
        }
    }
}
