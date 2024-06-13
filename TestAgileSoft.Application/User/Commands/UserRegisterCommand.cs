using MediatR;
using System.ComponentModel.DataAnnotations;
using TestAgileSoft.Domain.Dtos;

namespace TestAgileSoft.Application.User.Commands
{
    public record UserRegisterCommand
    (
        [Required] string UserName,
        [Required] string Nombre,
        [Required] string Password
    ): IRequest<UserDto>;
}
