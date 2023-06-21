using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Base.Infrastructure.Identity
{
    public class CurrentUserService :  ICurrentUserService
    {
        private readonly IHttpContextAccessor _context;

        public CurrentUserService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public bool IsAuthenticated
        {
            get
            {
                return _context.HttpContext.User.Identity.IsAuthenticated;
            }
        }

        public string UserId
        {
            get
            {
                var userId = _context.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? _context.HttpContext.User.FindFirst("sub")?.Value;

                return userId;
            }
        }

        public string Name
        {
            get
            {
                return string.Empty;
            }
        }

        public string Email
        {
            get
            {
                return _context.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            }
        }


    }
}
