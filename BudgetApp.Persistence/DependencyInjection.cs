using BudgetApp.Persistence.Interfaces;
using BudgetApp.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetApp.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IBudgetRepository), typeof(BudgetRepository));
            services.AddScoped(typeof(IExpenseRepository), typeof(ExpenseRepository));
            services.AddScoped(typeof(IIncomeRepository), typeof(IncomeRepository));
            services.AddScoped(typeof(ISavingRepository), typeof(SavingRepository));

            return services;
        }
    }
}
