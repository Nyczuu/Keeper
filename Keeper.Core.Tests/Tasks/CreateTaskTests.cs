using Keeper.CoreContract.Projects;
using Keeper.CoreContract.Tasks;
using Keeper.Data.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keeper.Core.Tests.Tasks
{
    [TestClass]
    public class CreateTaskTests : BaseTaskTests
    {
        [TestMethod]
        public void CreateTask()
        {
            var createTaskResponse = _client.TaskCreate(
                new TaskCreateRequest
                {
                    Name = GeneratePseudoRandomName<Task>(),
                    Description = _testDescription,
                    ProjectIdentifier = _testProjectIdentifier,
                });

            Assert.IsNotNull(createTaskResponse.Identifier);
            Assert.IsTrue(createTaskResponse.Type == TaskCreateResponseType.Success);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow("     ")]
        public void CreateTask_NameEmpty(string name)
        {
            var createTaskResponse = _client.TaskCreate(
                new TaskCreateRequest
                {
                    Name = name,
                    ProjectIdentifier = _testProjectIdentifier,
                });

            Assert.IsTrue(createTaskResponse.Type == TaskCreateResponseType.NameEmpty);
        }

        [DataTestMethod]
        [DataRow("EXISTINGTESTTASK")]
        [DataRow("existingtesttask")]
        [DataRow("ExistingTestTask     ")]
        [DataRow("     ExistingTestTask")]
        public void CreateTask_NameExists(string name)
        {
            var createFirstTaskResponse = _client.TaskCreate(
                new TaskCreateRequest
                {
                    Name = "ExistingTestTask",
                    ProjectIdentifier = _testProjectIdentifier,
                });

            var createSameNameTaskResponse = _client.TaskCreate(
                new TaskCreateRequest
                {
                    Name = name,
                    ProjectIdentifier = _testProjectIdentifier,
                });

            Assert.IsTrue(createSameNameTaskResponse.Type == TaskCreateResponseType.NameExists);
        }

        [TestMethod]
        public void CreateTask_ProjectDoNotExists()
        {
            var createTaskResponse = _client.TaskCreate(
                new TaskCreateRequest
                {
                    Name = GeneratePseudoRandomName<Task>(),
                    Description = _testDescription,
                    ProjectIdentifier = 0,
                });

            Assert.IsTrue(createTaskResponse.Type == TaskCreateResponseType.ProjectDoesNotExist);
        }
    }
}
