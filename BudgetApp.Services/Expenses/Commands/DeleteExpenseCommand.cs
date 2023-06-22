using AutoMapper;
using MediatR;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Expenses.Commands
{
    public class DeleteExpenseCommand : IRequest<string>
    {
        public int Id { get; set; }
    }

    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, string>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDbContext _context;

        public DeleteExpenseCommandHandler(IExpenseRepository expenseRepository, IMapper mapper, IBaseDbContext context)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepository.GetExpenseById(request.Id);

            if (expense == null)
                throw new Exception($"invaild expense with id {request.Id}");

            var result = await _expenseRepository.Delete(expense);

            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            if (result)
                return "expense successfully deleted";
            else
                throw new Exception("unable to delete expense due to some errors");
        }
    }
}
