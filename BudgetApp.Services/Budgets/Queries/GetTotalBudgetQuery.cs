using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Persistence.Interfaces;
using BudgetApp.Persistence.Repositories;
using BudgetApp.Persistence._Extentions;

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
                Expenses = Utils.TotalExpenses(expenses),
                Incomes = Utils.TotalIncomes(incomes),
                savings = Utils.TotalSavings(savings)
            };
        }
       
    }
}
