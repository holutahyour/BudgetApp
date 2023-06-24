using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Persistence.Interfaces;
using BudgetApp.Base.Domain.DTO;

namespace BudgetApp.Services.Budgets.Queries
{
    public class GetBudgetListQuery : IRequest<BudgetData[]>
    {
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
            var budgetDatas = _mapper.Map<BudgetData[]>(await _budgetRepository.GetAllBudgets());

            foreach (var budgetData in budgetDatas)
            {
                var expenses = await _expenseRepository.GetExpenseByBudgetId(budgetData.Id);
                budgetData.Expenses = _mapper.Map<ExpenseData[]>(expenses);

                var incomes = await _incomeRepository.GetIncomeByBudgetId(budgetData.Id);
                budgetData.Incomes = _mapper.Map<IncomeData[]>(incomes);

                var savings = await _savingRepository.GetSavingByBudgetId(budgetData.Id);
                budgetData.Savings = _mapper.Map<SavingData[]>(savings);
            }

            return budgetDatas;
        }
    }

}
