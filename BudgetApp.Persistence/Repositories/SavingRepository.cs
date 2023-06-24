using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Persistence.Repositories
{
    public class SavingRepository : ISavingRepository
    {
        private readonly IBaseDbContext _context;

        public SavingRepository(IBaseDbContext context)
        {
            _context = context;
        }

        public async Task<Saving> AddAsync(Saving saving)
        {
            await _context.Savings.AddAsync(saving);

            return saving;
        }

        public async Task<Saving[]> AddSavingsAsync(Saving[] savings)
        {
            await _context.Savings.AddRangeAsync(savings);

            return savings;
        }

        public Task<Saving> Update(Saving saving)
        {
            _context.Savings.Update(saving);

            return Task.FromResult(saving);
        }

        public Task<bool> Delete(Saving saving)
        {
            try
            {
                _context.Savings.Remove(saving);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public Task<Saving> GetSavingById(int id)
        {
            var saving = _context.Savings
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return saving;
        }

        public Task<Saving[]> GetSavingByBudgetId(int budgetId)
        {
            var savings = _context.Savings
                .Where(x => x.BudgetId == budgetId)
                .ToArrayAsync();

            return savings;
        }

        public Task<Saving[]> GetAllSavings()
        {
            var savings = _context.Savings.ToArrayAsync();

            return savings;
        }
    }
}
