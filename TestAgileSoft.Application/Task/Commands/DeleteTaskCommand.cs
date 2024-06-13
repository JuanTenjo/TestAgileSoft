using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TestAgileSoft.Application.Tasks.Commands
{
    public record  DeleteTaskCommand
    (
        [Required] Guid Id
    ) : IRequest;
}
