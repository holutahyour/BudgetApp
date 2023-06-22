using MediatR;
using Microsoft.AspNetCore.Mvc;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Services.Incomes.Commands;
using BudgetApp.Services.Incomes.Queries;
using BudgetApp.Base.Domain.Models;

namespace BudgetApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/incomes")]
    public class IncomeController : ControllerBase
    {
        private readonly ILogger<IncomeController> _logger;
        private readonly IMediator _mediator;

        public IncomeController(ILogger<IncomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _mediator.Send(new GetIncomeListQuery()));
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
                return Ok(await _mediator.Send(new GetIncomeQuery { Id = Id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(IncomeModel income)
        {
            try
            {
                return Ok(await _mediator.Send(new CreateIncomeCommand { Income = income }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int Id, [FromBody]Income income)
        {
            try
            {
                return Ok(await _mediator.Send(new UpdateIncomeCommand { Id = Id, Income = income }));
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
                return Ok(await _mediator.Send(new DeleteIncomeCommand { Id = Id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}