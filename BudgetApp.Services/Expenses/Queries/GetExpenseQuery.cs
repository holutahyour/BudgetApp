using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Expenses.Queries
{
    public class GetExpenseQuery : IRequest<Expense>
    {
        public int Id { get; set; }
    }

    public class GetExpenseQueryHandler : IRequestHandler<GetExpenseQuery, Expense>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public GetExpenseQueryHandler(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<Expense> Handle(GetExpenseQuery request, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepository.GetExpenseById(request.Id);

            if (expense == null)
                throw new Exception($"invaild expense with id {request.Id}");

            return expense;
        }
    }
}
