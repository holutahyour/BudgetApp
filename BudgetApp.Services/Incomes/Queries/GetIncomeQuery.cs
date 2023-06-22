using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Incomes.Queries
{
    public class GetIncomeQuery : IRequest<Income>
    {
        public int Id { get; set; }
    }

    public class GetIncomeQueryHandler : IRequestHandler<GetIncomeQuery, Income>
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;

        public GetIncomeQueryHandler(IIncomeRepository incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }

        public async Task<Income> Handle(GetIncomeQuery request, CancellationToken cancellationToken)
        {
            var income = await _incomeRepository.GetIncomeById(request.Id);

            if (income == null)
                throw new Exception($"invaild income with id {request.Id}");

            return income;
        }
    }
}
