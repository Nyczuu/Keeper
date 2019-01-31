using Keeper.CoreContract.Projects;
using Keeper.Data.Projects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keeper.Core.Tests.Projects
{
    [TestClass]
    public class DeleteProjectTests : BaseProjectTests
    {
        [TestMethod]
        public void DeleteProject()
        {
            var createProjectResponse = _client.ProjectCreate(
                 new ProjectCreateRequest { Name = GeneratePseudoRandomName<Project>()});

            var deleteProjectResponse = _client.ProjectDelete(
                new ProjectDeleteRequest { Identifiers = new int[] { createProjectResponse.Identifier.Value } });

            Assert.IsNotNull(deleteProjectResponse);
        }

        [TestMethod]
        public void DeleteProjects()
        {
            var createProjectResponse1 = _client.ProjectCreate(
                new ProjectCreateRequest { Name = GeneratePseudoRandomName<Project>() });

            var createProjectResponse2 = _client.ProjectCreate(
                new ProjectCreateRequest { Name = GeneratePseudoRandomName<Project>() });

            var deleteProjectResponse = _client.ProjectDelete(
               new ProjectDeleteRequest { Identifiers = new int[] 
                    {
                        createProjectResponse1.Identifier.Value,
                        createProjectResponse2.Identifier.Value
                    } });

            Assert.IsNotNull(deleteProjectResponse);
        }
    }
}
