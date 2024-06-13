using MediatR;
using System.ComponentModel.DataAnnotations;
using TestAgileSoft.Domain.Dtos;

namespace TestAgileSoft.Application.User.Commands
{
    public record UserLoginCommand
    (
        [Required] string userName,
        [Required] string password
    ) : IRequest<UserDto>;
}
