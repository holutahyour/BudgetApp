using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.DTO;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Domain.Model;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Users.Commands
{
    public class CreateUserCommand : IRequest<UserData>
    {
        public UserModel UserModel { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserData>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDbContext _context;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IBaseDbContext context)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserData> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user =_mapper.Map<User>(request.UserModel);

            user = await _userRepository.CreateUser(user, request.Password);

            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            var userData = _mapper.Map<UserData>(user);

            return userData;
        }
    }
}
