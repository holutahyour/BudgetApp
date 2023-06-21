using BudgetApp.Base.Domain.Entities;

namespace BudgetApp.Persistence.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user, string password);
        Task<User[]> GetAllUsers();
        Task<User> GetUserByUserId(string userId);
        Task<User> Login(string username, string password);
    }
}