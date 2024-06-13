using Microsoft.AspNetCore.Identity;
using TestAgileSoft.Domain.Dtos;
using TestAgileSoft.Domain.Entities;
using TestAgileSoft.Domain.Ports;

namespace TestAgileSoft.Domain.Services
{
    public class UserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserSession userSession;
        private readonly IJwtGenerator jwtGenerator;
        
        public UserService(
            IUserSession userSession,
            UserManager<User> userManager,
            IJwtGenerator jwtGenerator
        )
        {
            this.userManager = userManager;
            this.userSession = userSession;
            this.jwtGenerator = jwtGenerator;
        }
        public async Task<UserDto> GetUserAsync()
        {
            var user = await userManager.FindByNameAsync(userSession.GetUserSessionAsync());
            return TranformerUserToUserDto(user);   
        }

        public async Task<UserDto> LoginAsync(string userName, string password)
        {
            var findUser = await userManager.FindByNameAsync(userName);

            if (findUser != null)
            {
                return TranformerUserToUserDto(findUser);
            }

            var result = await signInManager.CheckPasswordSignInAsync(findUser, password, false);

            if (result.Succeeded)
            {
                return TranformerUserToUserDto(findUser);
            }

            throw new Exception();
        }

        public async Task<UserDto> RegisterUser(UserRegisterDto userRegisterDto)
        {
            var user = new User
            {
                Nombre = userRegisterDto.Nombre,
                UserName = userRegisterDto.UserName,
            };

            var result = await userManager.CreateAsync(user, userRegisterDto.Password);

            if (result.Succeeded)
            {
                return TranformerUserToUserDto(user);
            }

            throw new Exception();
        }

        private UserDto TranformerUserToUserDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Token = jwtGenerator.GenerateToken(user),
                UserName = user.UserName
            };
        }
    }
}
