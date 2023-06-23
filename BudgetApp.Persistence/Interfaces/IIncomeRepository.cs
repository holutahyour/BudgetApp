using BudgetApp.Base.Domain.Entities;

namespace BudgetApp.Persistence.Interfaces
{
    public interface IIncomeRepository
    {
        Task<Income> AddAsync(Income income);
        Task<Income[]> AddIncomesAsync(Income[] incomes);
        Task<bool> Delete(Income income);
        Task<Income[]> GetAllIncomes();
        Task<Income> GetIncomeByBudgetId(int budgetId);
        Task<Income> GetIncomeById(int id);
        Task<Income> Update(Income income);
    }
}