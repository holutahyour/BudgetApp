using MediatR;
using Microsoft.AspNetCore.Mvc;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Services.Expenses.Commands;
using BudgetApp.Services.Expenses.Queries;
using BudgetApp.Base.Domain.Models;

namespace BudgetApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/expenses")]
    public class ExpenseController : ControllerBase
    {
        private readonly ILogger<ExpenseController> _logger;
        private readonly IMediator _mediator;

        public ExpenseController(ILogger<ExpenseController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _mediator.Send(new GetExpenseListQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get_By_Id(int Id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetExpenseQuery { Id = Id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ExpenseModel expense)
        {
            try
            {
                return Ok(await _mediator.Send(new CreateExpenseCommand { Expense = expense }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int Id, [FromBody]Expense expense)
        {
            try
            {
                return Ok(await _mediator.Send(new UpdateExpenseCommand { Id = Id, Expense = expense }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteExpenseCommand { Id = Id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}