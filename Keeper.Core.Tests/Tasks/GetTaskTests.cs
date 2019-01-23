using Keeper.CoreContract.Projects;
using Keeper.CoreContract.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Keeper.Core.Tests.Tasks
{
    [TestClass()]
    public class GetTaskTests : BaseTaskTests
    {
        [TestMethod()]
        public void GetTask()
        {
            var testName = _testName;
            var projectIdentifier = new Client().CreateProject(
                new CreateProjectRequest { Name = _testName }).Identifier.Value;

            var createTaskResponse = _client.CreateTask(
                new CreateTaskRequest
                {
                    Name = testName,
                    Description = _testDescription,
                    ProjectIdentifier = projectIdentifier,
                });

            var getTaskResponse = _client.GetTask(
                new GetTaskRequest
                {
                    TaskIdentifiers = new int[]
                    { createTaskResponse.Identifier.Value }
                });

            Assert.IsTrue(getTaskResponse.Items.Count() == 1);
            Assert.IsTrue(getTaskResponse.Items.Single().Identifier == createTaskResponse.Identifier.Value);
            Assert.IsTrue(getTaskResponse.Items.Single().Name == testName);
            Assert.IsTrue(getTaskResponse.Items.Single().Description == _testDescription);
        }

        [TestMethod()]
        public void GetTask_ByProjectIdentifier()
        {
            var testName = _testName;
            var projectIdentifier = new Client().CreateProject(
                new CreateProjectRequest { Name = _testName }).Identifier.Value;

            var createTaskResponse = _client.CreateTask(
                            new CreateTaskRequest
                            {
                                Name = testName,
                                ProjectIdentifier = projectIdentifier,
                            });

            var getTaskResponse= _client.GetTask(
                new GetTaskRequest { ProjectIdentifiers = new int[] { projectIdentifier } });

            Assert.IsTrue(getTaskResponse.Items.SingleOrDefault().Identifier == createTaskResponse.Identifier.Value);
            Assert.IsTrue(getTaskResponse.Items.SingleOrDefault().Name == testName);
        }
    }
}
