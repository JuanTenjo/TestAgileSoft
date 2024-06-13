using Microsoft.EntityFrameworkCore;
using TestAgileSoft.Domain.Entities;
using TestAgileSoft.Domain.Ports;
using TestAgileSoft.Infrastructure.Context;
using TestAgileSoft.Infrastructure.Helpers;

namespace TestAgileSoft.Infrastructure.Adapters
{
    public class TaskRepository : ITaskService
    {
        private readonly PersistenceContext context;

        public TaskRepository(
            PersistenceContext persistenceContext
        )
        {
            context = persistenceContext;
        }
        public async Task<Tasks> CreateTask(Tasks task)
        {
            _ = task ?? throw new ArgumentNullException(nameof(task), "Entity can not be null");

            await context.Tasks.AddAsync(task);
            await CommitAsync();
            return task;
        }

        public async Task DeleteTask(Guid idTask)
        {
            var task = await context.Tasks.FirstOrDefaultAsync(tasks => tasks.Id == idTask);

            if(task != null)
            {
                context.Remove(task);
                await CommitAsync().ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<Tasks>> GetTasksByUser(string id)
        {
            var result = context.Tasks.Where(tasks => tasks.UserId == id);

            return await result.AsNoTracking().ToListAsync();
        }

        public async Task<Tasks> UpdateTask(Tasks tasks)
        {
            context.Tasks.Update(tasks);
            await CommitAsync();

            return tasks;
        }

        public async Task CommitAsync()
        {
            context.ChangeTracker.DetectChanges();

            foreach (var entry in context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("CreatedOn").CurrentValue = DateTime.UtcNow.ConvertDateTimeToLocalZone();
                        break;
                    case EntityState.Modified:
                        entry.Property("LastModifiedOn").CurrentValue = DateTime.UtcNow.ConvertDateTimeToLocalZone();
                        break;
                }
            }

            await context.CommitAsync().ConfigureAwait(false);
        }

        public async Task<Tasks> GetTasksById(Guid id)
        {
            return await context.Tasks.FirstOrDefaultAsync(tasks => tasks.Id == id).ConfigureAwait(false);
        }
    }
}
