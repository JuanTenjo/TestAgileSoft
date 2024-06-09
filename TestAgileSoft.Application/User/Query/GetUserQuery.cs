using MediatR;
using TestAgileSoft.Application.User.Dtos;

namespace TestAgileSoft.Application.User.Query
{
    public record GetUserQuery : IRequest<UserDto>;
}
