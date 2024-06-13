using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestAgileSoft.Application.Dtos;
using TestAgileSoft.Application.Tasks.Commands;
using TestAgileSoft.Application.Tasks.Query;

namespace TestAgileSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator) => _mediator = mediator;

        [HttpPost("registerTask")]
        public async Task<TaskInfoDto> RegisterTaksAsync(CreateTaskCommand createTaskCommand) => await _mediator.Send(createTaskCommand);

        [HttpGet("task")]
        public async Task<IEnumerable<TaskInfoDto>> GetTakssByUserAsync(GetTasksByUserIdQuery getTasksByUserIdQuery) => await _mediator.Send(getTasksByUserIdQuery);

        [HttpPut("updateStatusTask")]
        public async Task<TaskInfoDto> UpdateStatusTaskAsync(UpdateTaskStatusCommand updateTaskStatusCommand) => await _mediator.Send(updateTaskStatusCommand);

        [HttpDelete("deleteTask")]
        public async Task<Unit> DeleteTaks(DeleteTaskCommand deleteTaskCommand) => await _mediator.Send(deleteTaskCommand);
    }
}
