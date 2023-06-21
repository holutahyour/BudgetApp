using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Budgets.Queries
{
    public class GetBudgetListQuery : IRequest<Budget[]>
    {
    }

    public class GetBudgetListQueryHandler : IRequestHandler<GetBudgetListQuery, Budget[]>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;

        public GetBudgetListQueryHandler(IBudgetRepository budgetRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
        }

        public Task<Budget[]> Handle(GetBudgetListQuery request, CancellationToken cancellationToken)
        {
            var budgets = _budgetRepository.GetAllBudgets();

            return budgets;
        }
    }

}
