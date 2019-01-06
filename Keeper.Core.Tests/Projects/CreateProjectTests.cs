using Keeper.CoreContract.Projects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Core.Tests.Projects
{
    [TestClass()]
    public class CreateProjectTests : BaseProjectTests
    {
        [TestMethod()]
        public void CreateProject()
        {
            var createProjectResponse = _client.CreateProject(
                new CreateProjectRequest
                {
                    Name = _testName,
                });

            Assert.IsNotNull(createProjectResponse.Identifier);
            Assert.IsTrue(createProjectResponse.Type == CreateProjectResponseType.Success);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow("     ")]
        public void CreateProject_EmptyNameValidation(string name)
        {
            var createProjectResponse = _client.CreateProject(
                new CreateProjectRequest
                {
                    Name = name
                });

            Assert.IsTrue(createProjectResponse.Type == CreateProjectResponseType.NameEmpty);
        }

        [DataTestMethod]
        [DataRow("EXISTINGTESTPROJECT")]
        [DataRow("existingtestproject")]
        [DataRow("ExistingTestProject     ")]
        [DataRow("     ExistingTestProject")]
        public void CreateProject_ExistingNameValidation(string name)
        {
            var createFirstProjectResponse = _client.CreateProject(
                new CreateProjectRequest
                {
                    Name = "ExistingTestProject"
                });

            var createSameNameProjectResponse1 = _client.CreateProject(
                new CreateProjectRequest
                {
                    Name = name
                });

            Assert.IsTrue(createFirstProjectResponse.Type == CreateProjectResponseType.NameExists);
        }
    }
}
