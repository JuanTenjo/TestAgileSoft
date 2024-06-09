using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TestAgileSoft.Domain.Ports;

namespace TestAgileSoft.Infrastructure.Adapters
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserSession(
            IHttpContextAccessor httpContextAccessor
        )
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetUserSessionAsync()
        {
            var username = httpContextAccessor.HttpContext!.User?.Claims
               .FirstOrDefault(user => user.Type == ClaimTypes.NameIdentifier)?.Value;

            return username ?? string.Empty;
        }
    }
}
