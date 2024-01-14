using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger _logger;

        public IdentityService(IApplicationDbContext context, ILogger<IdentityService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            throw new NotImplementedException();
        }

        public Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public object GetByUsername(int username)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(string username, Domain.AuthenticationUsers.User.UserRoles role)
        {
            return _context.Users.AnyAsync(u => u.UserName == username && u.UserRole == role);

        }

        Task<bool> IIdentityService.IsInRoleAsync(string userId, string role)
        {
            throw new NotImplementedException();
        }
    }
}
