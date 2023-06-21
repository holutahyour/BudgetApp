using BudgetApp.Base.Domain.Entities;

namespace BudgetApp.Persistence.Interfaces
{
    public interface IExpenseRepository
    {
        Task<Expense> AddAsync(Expense expense);
        Task<bool> Delete(Expense expense);
        Task<Expense[]> GetAllExpenses();
        Task<Expense> GetExpenseById(int id);
        Task<Expense> Update(Expense expense);
    }
}