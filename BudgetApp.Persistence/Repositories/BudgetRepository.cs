using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Persistence.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly IBaseDbContext _context;

        public BudgetRepository(IBaseDbContext context)
        {
            _context = context;
        }

        public async Task<Budget> AddAsync(Budget budget)
        {
            await _context.Budgets.AddAsync(budget);

            return budget;
        }

        public Task<Budget> Update(Budget budget)
        {
            _context.Budgets.Update(budget);

            return Task.FromResult(budget);
        }

        public Task<bool> Delete(Budget budget)
        {
            try
            {
                _context.Budgets.Remove(budget);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public Task<Budget> GetBudgetById(int id)
        {
            var budget = _context.Budgets
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return Task.FromResult(budget);
        }

        public Task<Budget[]> GetAllBudgets()
        {
            var budgets = _context.Budgets.ToArray();

            return Task.FromResult(budgets);
        }
    }
}
