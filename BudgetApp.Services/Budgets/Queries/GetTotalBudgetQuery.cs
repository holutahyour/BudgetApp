using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Persistence.Interfaces;
using BudgetApp.Persistence.Repositories;

namespace BudgetApp.Services.Budgets.Queries
{
    public class GetTotalBudgetQuery : IRequest<object>
    {
        public int Id { get; set; }
    }

    public class GetTotalBudgetQueryHandler : IRequestHandler<GetTotalBudgetQuery, object>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly ISavingRepository _savingRepository;
        private readonly IMapper _mapper;

        public GetTotalBudgetQueryHandler(IBudgetRepository budgetRepository, IIncomeRepository incomeRepository, IExpenseRepository expenseRepository, ISavingRepository savingRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository;
            _incomeRepository = incomeRepository;
            _expenseRepository = expenseRepository;
            _savingRepository = savingRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTotalBudgetQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _expenseRepository.GetAllExpenses();
            var incomes = await _incomeRepository.GetAllIncomes();
            var savings = await _savingRepository.GetAllSavings();


            return new
            {
                Expenses = TotalExpenses(expenses),
                Incomes = TotalIncomes(incomes),
                savings = TotalSavings(savings)
            };
        }

        public double TotalExpenses(Expense[] expenses)
        {
            double total = 0;

            foreach (var expense in expenses)
            {
                total += expense.Amount;
            }

            return total;
        }
        public double TotalIncomes(Income[] incomes)
        {
            double total = 0;

            foreach (var income in incomes)
            {
                total += income.Amount;
            }

            return total;
        }

        public double TotalSavings(Saving[] savings)
        {
            double total = 0;

            foreach (var saving in savings)
            {
                total += saving.Amount;
            }

            return total;
        }
    }
}
