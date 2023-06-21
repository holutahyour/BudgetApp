namespace BudgetApp.Base.Infrastructure.Identity
{
    public interface ICurrentUserService
    {
        string Email { get; }
        bool IsAuthenticated { get; }
        string Name { get; }
        string UserId { get; }
    }
}