using MediatR;
using TestAgileSoft.Domain.Dtos;
using TestAgileSoft.Domain.Services;

namespace TestAgileSoft.Application.User.Commands
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, UserDto>
    {
        private readonly UserService userService;

        public UserRegisterCommandHandler(
            UserService userService
        )
        {
            this.userService = userService;
        }

        public async Task<UserDto> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var userRegister = new UserRegisterDto()
            {
                Nombre = request.Nombre,
                UserName = request.UserName,
                Password = request.Password
            };

            return await userService.RegisterUser(userRegister);
        }
    }
}
