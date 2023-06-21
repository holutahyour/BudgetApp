using BudgetApp.Base.Domain.Model;
using BudgetApp.Services.Users.Commands;
using BudgetApp.Services.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _mediator.Send(new GetUserListQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get_By_Id(string Id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetUserQuery { UserId = Id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserModel userModel)
        {
            try
            {
                return Ok(await _mediator.Send(new CreateUserCommand { UserModel = userModel, Password = userModel.Password }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                return Ok(await _mediator.Send(new LoginUserCommand { Username = username, Password = password }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}