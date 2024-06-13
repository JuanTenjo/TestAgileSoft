using TestAgileSoft.Domain.Entities;

namespace TestAgileSoft.Domain.Ports
{
    public interface ITaskService
    {
        Task<IEnumerable<Tasks>> GetTasksByUser(string id);
        Task<Tasks> CreateTask(Tasks task);
        Task<Tasks> UpdateTask(Tasks tasks);
        Task<Tasks> GetTasksById(Guid id);
        Task DeleteTask(Guid idTask);
    }
}
