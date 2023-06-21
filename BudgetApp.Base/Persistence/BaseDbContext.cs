using BudgetApp.Base.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using BudgetApp.Base.Infrastructure.Identity;

namespace BudgetApp.Base.Persistence
{
    public class BaseDbContext : IdentityDbContext<User, UserRole, string>, IBaseDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public BaseDbContext(
            DbContextOptions<BaseDbContext> options,
            ICurrentUserService currentUserService
            ) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Saving> Savings { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<AuditEntity> entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.Email != null ? _currentUserService.UserId : "SYSTEM";
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _currentUserService.Email != null ? _currentUserService.UserId : "SYSTEM";
                        entry.Entity.UpdatedOn = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
