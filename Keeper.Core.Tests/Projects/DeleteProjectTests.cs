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
            var createUserResponse = _client.CreateUser(
                new CreateProjectRequest { });

            var deleteUserResponse = _client.DeleteUser(
                new DeleteProjectRequest { Identifiers = new int[] { createProjectResponse.Identifier.Value } });

            Assert.IsNotNull(deleteUserResponse);
        }





    }
}
