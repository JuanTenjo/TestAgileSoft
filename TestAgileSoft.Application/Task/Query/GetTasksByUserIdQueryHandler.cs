using AutoMapper;
using MediatR;
using TestAgileSoft.Application.Dtos;
using TestAgileSoft.Domain.Services;

namespace TestAgileSoft.Application.Tasks.Query
{
    public class GetTasksByUserIdQueryHandler : IRequestHandler<GetTasksByUserIdQuery, IEnumerable<TaskInfoDto>>
    {
        private readonly IMapper mapper;
        private readonly TaskService taskService;

        public GetTasksByUserIdQueryHandler(
            IMapper mapper,
            TaskService taskService
        )
        {
            this.mapper = mapper;
            this.taskService = taskService;
        }
        public async Task<IEnumerable<TaskInfoDto>> Handle(GetTasksByUserIdQuery query, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<TaskInfoDto>>(
                await taskService.GetTasksByUser(query.UserId)
            );
        }
    }
}
