using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Persistence.Interfaces;
using BudgetApp.Base.Domain.DTO;
using BudgetApp.Persistence._Extentions;

namespace BudgetApp.Services.Budgets.Queries
{
    public class GetBudgetListQuery : IRequest<BudgetData[]>
    {
        public bool GetCompleteData { get; set; }
        public int Take { get; set; }
    }

    public class GetBudgetListQueryHandler : IRequestHandler<GetBudgetListQuery, BudgetData[]>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly ISavingRepository _savingRepository;
        private readonly IMapper _mapper;

        public GetBudgetListQueryHandler(IBudgetRepository budgetRepository, IIncomeRepository incomeRepository, IExpenseRepository expenseRepository, ISavingRepository savingRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository;
            _incomeRepository = incomeRepository;
            _expenseRepository = expenseRepository;
            _savingRepository = savingRepository;
            _mapper = mapper;
        }

        public async Task<BudgetData[]> Handle(GetBudgetListQuery request, CancellationToken cancellationToken)
        {
            var budgetDatas = _mapper.Map<BudgetData[]>(await _budgetRepository.GetAllBudgets()).OrderByDescending(x => x.Date).ToArray();

            if (request.Take > 0) budgetDatas = budgetDatas.Take(request.Take).ToArray();

            if (request.GetCompleteData == false) return budgetDatas;

            foreach (var budgetData in budgetDatas)
            {
                var expenses = await _expenseRepository.GetExpenseByBudgetId(budgetData.Id);
                budgetData.Expenses = _mapper.Map<ExpenseData[]>(expenses);
                budgetData.TotalExpenses = Utils.TotalExpenses(expenses);

                var incomes = await _incomeRepository.GetIncomeByBudgetId(budgetData.Id);
                budgetData.Incomes = _mapper.Map<IncomeData[]>(incomes);
                budgetData.TotalIncome = Utils.TotalIncomes(incomes);

                var savings = await _savingRepository.GetSavingByBudgetId(budgetData.Id);
                budgetData.Savings = _mapper.Map<SavingData[]>(savings);
                budgetData.TotalSavings = Utils.TotalSavings(savings);

            }

            return budgetDatas;
        }
    }

}
