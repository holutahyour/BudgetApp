using BudgetApp.Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Base.Persistence
{
    public interface IBaseDbContext
    {
        DbSet<Budget> Budgets { get; set; }
        DbSet<Expense> Expenses { get; set; }
        DbSet<Income> Incomes { get; set; }
        DbSet<Saving> Savings { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}