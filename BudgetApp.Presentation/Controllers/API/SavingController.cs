using MediatR;
using Microsoft.AspNetCore.Mvc;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Services.Savings.Commands;
using BudgetApp.Services.Savings.Queries;
using BudgetApp.Base.Domain.Models;

namespace BudgetApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/savings")]
    public class SavingController : ControllerBase
    {
        private readonly ILogger<SavingController> _logger;
        private readonly IMediator _mediator;

        public SavingController(ILogger<SavingController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _mediator.Send(new GetSavingListQuery()));
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
                return Ok(await _mediator.Send(new GetSavingQuery { Id = Id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(SavingModel saving)
        {
            try
            {
                return Ok(await _mediator.Send(new CreateSavingCommand { Saving = saving }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int Id, [FromBody]Saving saving)
        {
            try
            {
                return Ok(await _mediator.Send(new UpdateSavingCommand { Id = Id, Saving = saving }));
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
                return Ok(await _mediator.Send(new DeleteSavingCommand { Id = Id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}