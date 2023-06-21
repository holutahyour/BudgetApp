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

            return services;
        }
    }
}
