using BudgetApp.Base.Domain.Entities;

namespace BudgetApp.Persistence.Interfaces
{
    public interface ISavingRepository
    {
        Task<Saving> AddAsync(Saving saving);
        Task<Saving[]> AddSavingsAsync(Saving[] savings);
        Task<bool> Delete(Saving saving);
        Task<Saving[]> GetAllSavings();
        Task<Saving[]> GetSavingByBudgetId(int budgetId);
        Task<Saving> GetSavingById(int id);
        Task<Saving> Update(Saving saving);
    }
}