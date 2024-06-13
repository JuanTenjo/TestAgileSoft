using MediatR;
using TestAgileSoft.Domain.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestAgileSoft.Application.Tasks.Commands
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly TaskService taskService;

        public DeleteTaskCommandHandler(
            TaskService taskService
        )
        {
            this.taskService = taskService;
        }

        public async Task<Unit> Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
        {
            await taskService.DeleteTask(command.Id);
            return Unit.Value;
        }
    }
}
