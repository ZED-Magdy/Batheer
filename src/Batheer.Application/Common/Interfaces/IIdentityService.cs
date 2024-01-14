using Batheer.Application.Common.Models;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, Domain.AuthenticationUsers.User.UserRoles role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
        object GetByUsername(int username);
        Task<bool> IsInRoleAsync(string userId, string role);
    }
}
