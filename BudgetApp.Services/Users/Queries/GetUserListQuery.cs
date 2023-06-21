using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.DTO;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Users.Queries
{
    public class GetUserListQuery : IRequest<UserData[]>
    {
    }

    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserData[]>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserData[]> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userDatas = new List<UserData>();

            var users = await _userRepository.GetAllUsers();

            foreach (var user in users)
            {

                var userData = _mapper.Map<UserData>(user);

                userDatas.Add(userData);
            }

            return userDatas.OrderBy(x => x.LastName).OrderBy(x => x.FirstName).ToArray();
        }
    }

}
