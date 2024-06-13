using TestAgileSoft.Domain.Entities;
using TestAgileSoft.Domain.Enums;
using TestAgileSoft.Domain.Exceptions;
using TestAgileSoft.Domain.Helpers;
using TestAgileSoft.Domain.Ports;

namespace TestAgileSoft.Domain.Services
{
    public class TaskService
    {
        private readonly ITaskService taskService;

        public TaskService(
            ITaskService taskService
        )
        {
            this.taskService = taskService;
        }

        public Task<Tasks> CreateTaskAsync(Tasks task)
        {
            if(task == null)
            {
                throw new AppException("No llego la entidad");
            }

            return taskService.CreateTask(task);
        }

        public async Task<Tasks> UpdateStatusTaskAsync(Guid idTask, TasksStatus status)
        {
            var task = await taskService.GetTasksById(idTask);

            task.Status = status.GetDescription();

            return await taskService.UpdateTask(task);
        }

        public async Task<IEnumerable<Tasks>> GetTasksByUser(string idUser)
        {
            return await taskService.GetTasksByUser(idUser);
        }

        public async Task DeleteTask(Guid idTask)
        {
            await taskService.DeleteTask(idTask);
        }
    }
}
