using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Base.Domain.Entities
{
    public class UserRole : IdentityRole
    {
        public UserRole() : base()
        {

        }

        public UserRole(string roleName) : base(roleName)
        {

        }

        public UserRole(string roleName, string description, DateTime createdOn) : base(roleName)
        {
            Description = description;
            CreatedOn = createdOn;
        }

        public string RoleName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
