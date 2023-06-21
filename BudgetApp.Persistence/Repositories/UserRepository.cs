using BudgetApp.Base.Domain.Entities;
using BudgetApp.Persistence.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace BudgetApp.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(UserManager<User> userManager, RoleManager<UserRole> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<User> CreateUser(User user, string password)
        {
            user.Id = Guid.NewGuid().ToString();

            var existing_user = await _userManager.FindByNameAsync(user.UserName);

            if (existing_user != null)
                throw new Exception("username already exist");

            existing_user = await _userManager.FindByEmailAsync(user.Email);

            if (existing_user != null)
                throw new Exception("email already exist");

            if (existing_user == null)
            {
                var result = await _userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    var errors = new List<string>();

                    foreach (var error in result.Errors)
                    {
                        errors.Add($"{error.Description}");
                    }

                    throw new Exception(JsonSerializer.Serialize(errors));
                }
            }

            return user;
        }

        public Task<User[]> GetAllUsers()
        {
            var users = _userManager.Users.ToArray();

            return Task.FromResult(users);
        }

        public async Task<User> GetUserByUserId(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                throw new Exception("invalid username and password");
            }

        }
    }
}
