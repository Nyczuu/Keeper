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
    public class DeleteProjectTests : BaseProjectTests
    {
        [TestMethod()]
        public void DeleteProject()
        {
            var createProjectResponse = _client.CreateProject(
                 new CreateProjectRequest { Name = _testName});

            var deleteProjectResponse = _client.DeleteProject(
                new DeleteProjectRequest { Identifiers = new int[] { createProjectResponse.Identifier.Value } });

            Assert.IsNotNull(deleteProjectResponse);
        }





    }
}
