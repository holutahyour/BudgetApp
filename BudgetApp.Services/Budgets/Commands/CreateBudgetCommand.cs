using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Domain.Models;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;
using BudgetApp.Base.Domain.DTO;

namespace BudgetApp.Services.Budgets.Commands
{
    public class CreateBudgetCommand : IRequest<BudgetData>
    {
        public BudgetModel Budget { get; set; }
    }

    public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, BudgetData>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly ISavingRepository _savingRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDbContext _context;

        public CreateBudgetCommandHandler(IBudgetRepository budgetRepository, IIncomeRepository incomeRepository, IExpenseRepository expenseRepository, ISavingRepository savingRepository, IMapper mapper, IBaseDbContext context)
        {
            _budgetRepository = budgetRepository;
            _expenseRepository = expenseRepository;
            _savingRepository = savingRepository;
            _incomeRepository = incomeRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<BudgetData> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget =_mapper.Map<Budget>(request.Budget);

            var incomes = _mapper.Map<Income[]>(request.Budget.Incomes);
            var expenses = _mapper.Map<Expense[]>(request.Budget.Expenses);
            var savings = _mapper.Map<Saving[]>(request.Budget.Savings);

            budget = await _budgetRepository.Update(budget);

            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            foreach (var expense in expenses)
            {
                expense.BudgetId = budget.Id;
            }

            foreach (var income in incomes)
            {
                income.BudgetId = budget.Id;
            }

            foreach (var saving in savings)
            {
                saving.BudgetId = budget.Id;
            }

            expenses = await _expenseRepository.AddExpensesAsync(expenses);
            incomes = await _incomeRepository.AddIncomesAsync(incomes);
            savings = await _savingRepository.AddSavingsAsync(savings);


            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            var budgetData = _mapper.Map<BudgetData>(budget);

            budgetData.Expenses = _mapper.Map<ExpenseData[]>(expenses);
            budgetData.Incomes = _mapper.Map<IncomeData[]>(incomes);
            budgetData.Savings = _mapper.Map<SavingData[]>(savings);


            return budgetData;
        }
    }
}
