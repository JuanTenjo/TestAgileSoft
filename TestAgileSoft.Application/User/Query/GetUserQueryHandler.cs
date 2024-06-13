using MediatR;
using TestAgileSoft.Domain.Dtos;
using TestAgileSoft.Domain.Services;

namespace TestAgileSoft.Application.User.Query
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private UserService userService;

        public GetUserQueryHandler(
            UserService userService
        )
        {
            this.userService = userService;
        }
        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await userService.GetUserAsync();
        }
    }
}
