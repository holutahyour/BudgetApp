using Microsoft.Extensions.DependencyInjection;
using BudgetApp.Base.Infrastructure.Identity;

namespace BudgetApp.Base.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBase(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseDbContext), typeof(BaseDbContext));
            services.AddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));

            return services;
        }
    }
}
