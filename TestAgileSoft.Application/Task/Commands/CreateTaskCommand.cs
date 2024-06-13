using MediatR;
using System.ComponentModel.DataAnnotations;
using TestAgileSoft.Application.Dtos;

namespace TestAgileSoft.Application.Tasks.Commands
{
    public record CreateTaskCommand
    (
        [Required] Guid Id,
        [Required] string Name,
        [Required] string Status,
        [Required] string Description,
        [Required] string UserId
    ): IRequest<TaskInfoDto>;
}
