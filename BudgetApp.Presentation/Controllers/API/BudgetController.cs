using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Domain.Models;
using BudgetApp.Services.Budgets.Commands;
using BudgetApp.Services.Budgets.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/budgets")]
    public class BudgetController : ControllerBase
    {
        private readonly ILogger<BudgetController> _logger;
        private readonly IMediator _mediator;

        public BudgetController(ILogger<BudgetController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _mediator.Send(new GetBudgetListQuery()));
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
                return Ok(await _mediator.Send(new GetBudgetQuery { Id = Id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(BudgetModel budget)
        {
            try
            {
                return Ok(await _mediator.Send(new CreateBudgetCommand { Budget = budget }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] Budget budget)
        {
            try
            {
                return Ok(await _mediator.Send(new UpdateBudgetCommand { Id = Id, Budget = budget }));
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
                return Ok(await _mediator.Send(new DeleteBudgetCommand { Id = Id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}