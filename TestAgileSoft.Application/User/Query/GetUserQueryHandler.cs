using AutoMapper;
using MediatR;
using TestAgileSoft.Application.User.Dtos;
using TestAgileSoft.Domain.Services;

namespace TestAgileSoft.Application.User.Query
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IMapper mapper;
        private UserService userService;

        public GetUserQueryHandler(
            IMapper mapper,
            UserService userService
        )
        {
            this.mapper = mapper;
            this.userService = userService;
        }
        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userService.GetUserAsync();
            return mapper.Map<UserDto>(user);
        }
    }
}
