using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Domain.Models;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Expenses.Commands
{
    public class CreateExpenseCommand : IRequest<Expense>
    {
        public ExpenseModel Expense { get; set; }
    }

    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Expense>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDbContext _context;

        public CreateExpenseCommandHandler(IExpenseRepository expenseRepository, IMapper mapper, IBaseDbContext context)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Expense> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense =_mapper.Map<Expense>(request.Expense);

            expense = await _expenseRepository.Update(expense);

            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            var expenseData = _mapper.Map<Expense>(expense);

            return expenseData;
        }
    }
}
