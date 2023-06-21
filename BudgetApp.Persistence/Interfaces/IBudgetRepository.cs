using BudgetApp.Base.Domain.Entities;

namespace BudgetApp.Persistence.Interfaces
{
    public interface IBudgetRepository
    {
        Task<Budget> AddAsync(Budget budget);
        Task<bool> Delete(Budget budget);
        Task<Budget[]> GetAllBudgets();
        Task<Budget> GetBudgetById(int id);
        Task<Budget> Update(Budget budget);
    }
}