using MediatR;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using TestAgileSoft.Domain.Enums;
using TestAgileSoft.Domain.Helpers;
using TestAgileSoft.Domain.Ports;
using TestAgileSoft.Domain.Services;

namespace TestAgileSoft.Domain.Tests.Tasks
{
    [TestClass]
    public class TasksServiceTest
    {
        private ITaskService TaskServiceRepository { get; set; } = default!;

        private TaskService TaskService { get; set; } = default!;


        [TestInitialize]
        public void Initialize() 
        {
            TaskServiceRepository = Substitute.For<ITaskService>();

            TaskService = new(
                TaskServiceRepository
            );
        }

        [TestMethod]
        public async Task CreateTaskAsync_OK()
        {
            //Arrange

            Domain.Entities.Tasks tasks = new()
            {
                Name = "test",
                Description = "test",
                Status = TasksStatus.Resuelto.GetDescription(),
                UserId = "12d323d"
            };


            TaskServiceRepository
                .CreateTask(tasks)
                .ReturnsForAnyArgs(tasks);

            //Act

            Domain.Entities.Tasks result = await TaskService.CreateTaskAsync(tasks);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(tasks.Name, result.Name);
            await TaskServiceRepository.ReceivedWithAnyArgs(1)
                .CreateTask(Arg.Any<Domain.Entities.Tasks>());
        }


        [TestMethod]
        public async Task UpdateTaskAsync_OK()
        {
            //Arrange
            Guid expectedId = Guid.NewGuid();
            TasksStatus taskStatus = TasksStatus.Resuelto;


            Domain.Entities.Tasks tasks = new()
            {
                Name = "test",
                Description = "test",
                Status = TasksStatus.Resuelto.GetDescription(),
                UserId = "12d323d"
            };


            TaskServiceRepository
                .UpdateTask(tasks)
                .ReturnsForAnyArgs(tasks);

            TaskServiceRepository
                .GetTasksById(expectedId)
                .ReturnsForAnyArgs(tasks);

            //Act

            Domain.Entities.Tasks result = await TaskService.UpdateStatusTaskAsync(expectedId, taskStatus);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(tasks.Name, result.Name);
            await TaskServiceRepository.ReceivedWithAnyArgs(1)
                .UpdateTask(Arg.Any<Domain.Entities.Tasks>());
            await TaskServiceRepository.ReceivedWithAnyArgs(1)
                .GetTasksById(Arg.Any<Guid>());
        }

        [TestMethod]
        public async Task GetTaskByUserAsync_OK()
        {
            //Arrange
            string expectedIdUser = "12D23D23D23D23D";

            IEnumerable<Domain.Entities.Tasks> tasks = new List<Domain.Entities.Tasks>
            {
                new Domain.Entities.Tasks
                {
                    Name = "test",
                    Description = "test",
                    Status = TasksStatus.Resuelto.GetDescription(),
                    UserId = "123"
                }
            };

            TaskServiceRepository
                .GetTasksByUser(expectedIdUser)
                .ReturnsForAnyArgs(tasks);

            //Act

            IEnumerable<Domain.Entities.Tasks> result = await TaskService.GetTasksByUser(expectedIdUser);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(tasks, result);
            await TaskServiceRepository.ReceivedWithAnyArgs(1)
                .GetTasksByUser(Arg.Any<string>());
        }

        [TestMethod]
        public async Task DeleteTaskAsync_OK()
        {
            //Arrange
            Guid expectedId = Guid.NewGuid();

            TaskServiceRepository
                .DeleteTask(expectedId)
                .Returns(Task.FromResult(Unit.Value));

            //Act
            await TaskService.DeleteTask(expectedId);

            //Assert
            await TaskServiceRepository.ReceivedWithAnyArgs(1)
                .DeleteTask(Arg.Any<Guid>());
        }
    }
}
