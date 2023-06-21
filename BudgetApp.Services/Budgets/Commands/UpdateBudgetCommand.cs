using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Budgets.Commands
{
    public class UpdateBudgetCommand : IRequest<Budget>
    {
        public int Id { get; set; }
        public Budget Budget { get; set; }
    }

    public class UpdateBudgetCommandHandler : IRequestHandler<UpdateBudgetCommand, Budget>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDbContext _context;

        public UpdateBudgetCommandHandler(IBudgetRepository budgetRepository, IMapper mapper, IBaseDbContext context)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Budget> Handle(UpdateBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget = request.Budget;

            //var result = _budgetRepository.GetAllBudgets().Result.Any(x => x.Id == request.Id);

            //if (!result)
            //    throw new Exception($"invaild budget with id {request.Id}");

            budget.Id = request.Id;

            budget = await _budgetRepository.Update(request.Budget);

            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            var budgetData = _mapper.Map<Budget>(budget);

            return budgetData;
        }
    }
}
