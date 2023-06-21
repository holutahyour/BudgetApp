using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Expenses.Commands
{
    public class UpdateExpenseCommand : IRequest<Expense>
    {
        public int Id { get; set; }
        public Expense Expense { get; set; }
    }

    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, Expense>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDbContext _context;

        public UpdateExpenseCommandHandler(IExpenseRepository expenseRepository, IMapper mapper, IBaseDbContext context)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Expense> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = request.Expense;

            //var result = _expenseRepository.GetAllExpenses().Result.Any(x => x.Id == request.Id);

            //if (!result)
            //    throw new Exception($"invaild expense with id {request.Id}");

            expense.Id = request.Id;

            expense = await _expenseRepository.Update(request.Expense);

            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            var expenseData = _mapper.Map<Expense>(expense);

            return expenseData;
        }
    }
}
