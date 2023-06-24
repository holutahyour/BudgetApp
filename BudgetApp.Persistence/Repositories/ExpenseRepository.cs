using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Expense[]> AddExpensesAsync(Expense[] expenses)
        {
            await _context.Expenses.AddRangeAsync(expenses);

            return expenses;
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
                .FirstOrDefaultAsync();

            return expense;
        }

        public Task<Expense[]> GetExpenseByBudgetId(int budgetId)
        {
            var expense = _context.Expenses
                .Where(x => x.BudgetId == budgetId)
                .ToArrayAsync();

            return expense;
        }

        public Task<Expense[]> GetAllExpenses()
        {
            var expenses = _context.Expenses.ToArrayAsync();

            return expenses;
        }
    }
}
