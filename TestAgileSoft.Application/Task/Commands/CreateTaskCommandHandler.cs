using AutoMapper;
using MediatR;
using TestAgileSoft.Application.Dtos;
using TestAgileSoft.Domain.Entities;
using TestAgileSoft.Domain.Services;

namespace TestAgileSoft.Application.Tasks.Commands
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskInfoDto>
    {
        private readonly IMapper mapper;
        private readonly TaskService taskService;

        public CreateTaskCommandHandler(
            IMapper mapper,
            TaskService taskService
        )
        {
            this.mapper = mapper;
            this.taskService = taskService;
        }

        public async Task<TaskInfoDto> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
        {
            return mapper.Map<TaskInfoDto>(
                await taskService.CreateTaskAsync(
                    mapper.Map<Domain.Entities.Tasks>(command)
                )
            );
        }
    }
}
