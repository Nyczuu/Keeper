using Keeper.CoreContract.Projects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Keeper.Core.Tests.Projects
{
    [TestClass()]
    public class GetUserTests : BaseProjectTests
    {
        [TestMethod()]
        public void GetProject()
        {
            var testName = _testName;
            var createProjectResponse = _client.CreateProject(
                new CreateProjectRequest { Name = testName });

            var getProjectResponse = _client.GetProject(
                new GetProjectRequest
                {
                    ProjectsIdentifiers = new int[]
                    { createProjectResponse.Identifier.Value }
                });

            Assert.IsTrue(getProjectResponse.Items.Count() == 1);
            Assert.IsTrue(getProjectResponse.Items.Single().Identifier == createProjectResponse.Identifier.Value);
            Assert.IsTrue(getProjectResponse.Items.Single().Name == testName);
        }

        [TestMethod()]
        public void GetProject_ByName()
        {
            var testName = _testName;
            var createProjectResponse = _client.CreateProject(
                new CreateProjectRequest { Name = testName });

            var getProjectResponse = _client.GetProject(
                new GetProjectRequest { SearchKeyword = testName });

            Assert.IsTrue(getProjectResponse.Items.FirstOrDefault().Identifier == createProjectResponse.Identifier.Value);
            Assert.IsTrue(getProjectResponse.Items.FirstOrDefault().Name == testName);
        }
    }
}