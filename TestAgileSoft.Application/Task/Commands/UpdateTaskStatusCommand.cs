using MediatR;
using System.ComponentModel.DataAnnotations;
using TestAgileSoft.Application.Dtos;
using TestAgileSoft.Domain.Enums;

namespace TestAgileSoft.Application.Tasks.Commands
{
    public record UpdateTaskStatusCommand
    (
        [Required] Guid Id,
        [Required] TasksStatus Status
    ): IRequest<TaskInfoDto>;
}
