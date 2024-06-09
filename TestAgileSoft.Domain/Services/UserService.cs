using Microsoft.AspNetCore.Identity;
using TestAgileSoft.Domain.Entities;
using TestAgileSoft.Domain.Ports;

namespace TestAgileSoft.Domain.Services
{
    public class UserService
    {
        private readonly UserManager<User> userManager;
        private readonly IUserSession userSession;
        public UserService(
            IUserSession userSession,
            UserManager<User> userManager
        )
        {
            this.userManager = userManager;
            this.userSession = userSession;
        }
        public async Task<User> GetUserAsync()
        {
            return await userManager.FindByNameAsync(userSession.GetUserSessionAsync());
        }
    }
}
