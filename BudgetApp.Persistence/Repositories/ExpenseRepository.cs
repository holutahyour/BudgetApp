using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Persistence.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly IBaseDbContext _context;

        public ExpenseRepository(IBaseDbContext context)
        {
            _context = context;
        }

        public async Task<Expense> AddAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);

            return expense;
        }

        public Task<Expense> Update(Expense expense)
        {
            _context.Expenses.Update(expense);

            return Task.FromResult(expense);
        }

        public Task<bool> Delete(Expense expense)
        {
            try
            {
                _context.Expenses.Remove(expense);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public Task<Expense> GetExpenseById(int id)
        {
            var expense = _context.Expenses
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return Task.FromResult(expense);
        }

        public Task<Expense[]> GetAllExpenses()
        {
            var expenses = _context.Expenses.ToArray();

            return Task.FromResult(expenses);
        }
    }
}
