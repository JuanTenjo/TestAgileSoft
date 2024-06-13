using MediatR;
using TestAgileSoft.Domain.Dtos;
using TestAgileSoft.Domain.Services;

namespace TestAgileSoft.Application.User.Commands
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserDto>
    {
        private readonly UserService userService;

        public UserLoginCommandHandler(
            UserService userService
        )
        {
            this.userService = userService;
        }

        public async Task<UserDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            return await userService.LoginAsync(request.userName, request.password);
        }
    }
}
