using Keeper.CoreContract.Projects;
using Keeper.Data.Projects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keeper.Core.Tests.Projects
{
    [TestClass]
    public class CreateProjectTests : BaseProjectTests
    {
        [TestMethod]
        public void CreateProject()
        {
            var createProjectResponse = _client.CreateProject(
                new CreateProjectRequest { Name = GeneratePseudoRandomName<Project>() });

            Assert.IsNotNull(createProjectResponse.Identifier);
            Assert.IsTrue(createProjectResponse.Type == CreateProjectResponseType.Success);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow("     ")]
        public void CreateProject_NameEmpty(string name)
        {
            var createProjectResponse = _client.CreateProject(
                new CreateProjectRequest { Name = name });

            Assert.IsTrue(createProjectResponse.Type == CreateProjectResponseType.NameEmpty);
        }

        [DataTestMethod]
        [DataRow("EXISTINGTESTPROJECT")]
        [DataRow("existingtestproject")]
        [DataRow("ExistingTestProject     ")]
        [DataRow("     ExistingTestProject")]
        public void CreateProject_NameExists(string name)
        {
            var createFirstProjectResponse = _client.CreateProject(
                new CreateProjectRequest { Name = "ExistingTestProject" });

            var createSameNameProjectResponse = _client.CreateProject(
                new CreateProjectRequest { Name = name });

            Assert.IsTrue(createSameNameProjectResponse.Type == CreateProjectResponseType.NameExists);
        }
    }
}
