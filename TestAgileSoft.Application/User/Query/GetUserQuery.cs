using MediatR;
using TestAgileSoft.Domain.Dtos;

namespace TestAgileSoft.Application.User.Query
{
    public record GetUserQuery : IRequest<UserDto>;
}
