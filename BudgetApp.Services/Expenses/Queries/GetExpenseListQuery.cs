using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Expenses.Queries
{
    public class GetExpenseListQuery : IRequest<Expense[]>
    {
    }

    public class GetExpenseListQueryHandler : IRequestHandler<GetExpenseListQuery, Expense[]>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public GetExpenseListQueryHandler(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public Task<Expense[]> Handle(GetExpenseListQuery request, CancellationToken cancellationToken)
        {
            var expenses = _expenseRepository.GetAllExpenses();

            return expenses;
        }
    }

}
