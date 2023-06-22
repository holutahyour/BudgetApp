using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Savings.Queries
{
    public class GetSavingListQuery : IRequest<Saving[]>
    {
    }

    public class GetSavingListQueryHandler : IRequestHandler<GetSavingListQuery, Saving[]>
    {
        private readonly ISavingRepository _incomeRepository;
        private readonly IMapper _mapper;

        public GetSavingListQueryHandler(ISavingRepository incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }

        public Task<Saving[]> Handle(GetSavingListQuery request, CancellationToken cancellationToken)
        {
            var incomes = _incomeRepository.GetAllSavings();

            return incomes;
        }
    }

}
