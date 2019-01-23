using Keeper.CoreContract.Projects;
using Keeper.CoreContract.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keeper.Core.Tests.Tasks
{
    [TestClass()]
    public class CreateTaskTests : BaseTaskTests
    {
        [TestMethod()]
        public void CreateTask()
        {
            var projectIdentifier = new Client().CreateProject(
                new CreateProjectRequest { Name = _testName }).Identifier.Value;

            var createTaskResponse = _client.CreateTask(
                new CreateTaskRequest
                {
                    Name = _testName,
                    Description = _testDescription,
                    ProjectIdentifier = projectIdentifier,
                });

            Assert.IsNotNull(createTaskResponse.Identifier);
            Assert.IsTrue(createTaskResponse.Type == CreateTaskResponseType.Success);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow("     ")]
        public void CreateTask_NameEmpty(string name)
        {
            var projectIdentifier = new Client().CreateProject(
                new CreateProjectRequest { Name = _testName }).Identifier.Value;

            var createTaskResponse = _client.CreateTask(
                new CreateTaskRequest
                {
                    Name = name,
                    ProjectIdentifier = projectIdentifier,
                });

            Assert.IsTrue(createTaskResponse.Type == CreateTaskResponseType.NameEmpty);
        }

        [DataTestMethod]
        [DataRow("EXISTINGTESTTASK")]
        [DataRow("existingtesttask")]
        [DataRow("ExistingTestTask     ")]
        [DataRow("     ExistingTestTask")]
        public void CreateTask_NameExists(string name)
        {
            var projectIdentifier = new Client().CreateProject(
                new CreateProjectRequest { Name = _testName }).Identifier.Value;

            var createFirstTaskResponse = _client.CreateTask(
                new CreateTaskRequest
                {
                    Name = "ExistingTestTask",
                    ProjectIdentifier = projectIdentifier,
                });

            var createSameNameTaskResponse = _client.CreateTask(
                new CreateTaskRequest
                {
                    Name = name,
                    ProjectIdentifier = projectIdentifier,
                });

            Assert.IsTrue(createSameNameTaskResponse.Type == CreateTaskResponseType.NameExists);
        }

        [TestMethod()]
        public void CreateTask_ProjectDoNotExists()
        {
            var createTaskResponse = _client.CreateTask(
                new CreateTaskRequest
                {
                    Name = _testName,
                    Description = _testDescription,
                    ProjectIdentifier = 0,
                });

            Assert.IsTrue(createTaskResponse.Type == CreateTaskResponseType.ProjectDoNotExists);
        }
    }
}
