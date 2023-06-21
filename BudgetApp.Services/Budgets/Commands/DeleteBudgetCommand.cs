using AutoMapper;
using MediatR;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Budgets.Commands
{
    public class DeleteBudgetCommand : IRequest<string>
    {
        public int Id { get; set; }
    }

    public class DeleteBudgetCommandHandler : IRequestHandler<DeleteBudgetCommand, string>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDbContext _context;

        public DeleteBudgetCommandHandler(IBudgetRepository budgetRepository, IMapper mapper, IBaseDbContext context)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget = await _budgetRepository.GetBudgetById(request.Id);

            if (budget == null)
                throw new Exception($"invaild budget with id {budget.Id}");

            var result = await _budgetRepository.Delete(budget);

            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            if (result)
                return "budget successfully deleted";
            else
                throw new Exception("unable to delete budget due to some errors");
        }
    }
}
