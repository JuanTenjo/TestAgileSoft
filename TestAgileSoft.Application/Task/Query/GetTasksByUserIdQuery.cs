using MediatR;
using System.ComponentModel.DataAnnotations;
using TestAgileSoft.Application.Dtos;

namespace TestAgileSoft.Application.Tasks.Query
{
    public record GetTasksByUserIdQuery
    (
        [Required] string UserId
    ): IRequest<IEnumerable<TaskInfoDto>>;
}
