using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Budgets.Queries
{
    public class GetBudgetQuery : IRequest<Budget>
    {
        public int Id { get; set; }
    }

    public class GetBudgetQueryHandler : IRequestHandler<GetBudgetQuery, Budget>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;

        public GetBudgetQueryHandler(IBudgetRepository budgetRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
        }

        public async Task<Budget> Handle(GetBudgetQuery request, CancellationToken cancellationToken)
        {
            var budget = await _budgetRepository.GetBudgetById(request.Id);

            return budget;
        }
    }
}
