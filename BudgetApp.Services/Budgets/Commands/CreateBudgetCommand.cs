using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Domain.Models;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Budgets.Commands
{
    public class CreateBudgetCommand : IRequest<Budget>
    {
        public BudgetModel Budget { get; set; }
    }

    public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, Budget>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDbContext _context;

        public CreateBudgetCommandHandler(IBudgetRepository budgetRepository, IMapper mapper, IBaseDbContext context)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Budget> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget =_mapper.Map<Budget>(request.Budget);

            budget = await _budgetRepository.Update(budget);

            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            var budgetData = _mapper.Map<Budget>(budget);

            return budgetData;
        }
    }
}
