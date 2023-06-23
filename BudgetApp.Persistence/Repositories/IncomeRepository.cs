using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Persistence.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly IBaseDbContext _context;

        public IncomeRepository(IBaseDbContext context)
        {
            _context = context;
        }

        public async Task<Income> AddAsync(Income income)
        {
            await _context.Incomes.AddAsync(income);

            return income;
        }

        public async Task<Income[]> AddIncomesAsync(Income[] incomes)
        {
            await _context.Incomes.AddRangeAsync(incomes);

            return incomes;
        }
        public Task<Income> Update(Income income)
        {
            _context.Incomes.Update(income);

            return Task.FromResult(income);
        }

        public Task<bool> Delete(Income income)
        {
            try
            {
                _context.Incomes.Remove(income);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public Task<Income> GetIncomeById(int id)
        {
            var income = _context.Incomes
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return income;
        }

        public Task<Income> GetIncomeByBudgetId(int budgetId)
        {
            var income = _context.Incomes
                .Where(x => x.BudgetId == budgetId)
                .FirstOrDefaultAsync();

            return income;
        }

        public Task<Income[]> GetAllIncomes()
        {
            var incomes = _context.Incomes.ToArrayAsync();

            return incomes;
        }
    }
}
