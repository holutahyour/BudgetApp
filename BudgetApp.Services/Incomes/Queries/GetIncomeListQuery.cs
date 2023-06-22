using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Incomes.Queries
{
    public class GetIncomeListQuery : IRequest<Income[]>
    {
    }

    public class GetIncomeListQueryHandler : IRequestHandler<GetIncomeListQuery, Income[]>
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;

        public GetIncomeListQueryHandler(IIncomeRepository incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }

        public Task<Income[]> Handle(GetIncomeListQuery request, CancellationToken cancellationToken)
        {
            var incomes = _incomeRepository.GetAllIncomes();

            return incomes;
        }
    }

}
