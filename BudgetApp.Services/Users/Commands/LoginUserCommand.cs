using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.DTO;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Users.Commands
{
    public class LoginUserCommand : IRequest<UserData>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserData>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserData> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Login(request.Username, request.Password);

            var userData = _mapper.Map<UserData>(user);

            return userData;

        }
    }
}
