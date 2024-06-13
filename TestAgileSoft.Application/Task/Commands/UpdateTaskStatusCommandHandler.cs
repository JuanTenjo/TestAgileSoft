using AutoMapper;
using MediatR;
using TestAgileSoft.Application.Dtos;
using TestAgileSoft.Domain.Services;

namespace TestAgileSoft.Application.Tasks.Commands
{
    public class UpdateTaskStatusCommandHandler : IRequestHandler<UpdateTaskStatusCommand, TaskInfoDto>
    {
        private readonly IMapper mapper;
        private readonly TaskService taskService;

        public UpdateTaskStatusCommandHandler(
            IMapper mapper,
            TaskService taskService
        )
        {
            this.mapper = mapper;
            this.taskService = taskService;
        }
        public async Task<TaskInfoDto> Handle(UpdateTaskStatusCommand command, CancellationToken cancellationToken)
        {
            return mapper.Map<TaskInfoDto>
            (
                await taskService.UpdateStatusTaskAsync(command.Id, command.Status)
            );
        }
    }
}
