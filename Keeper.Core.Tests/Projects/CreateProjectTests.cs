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
    public class CreateProjectTests
    {
        [TestMethod()]
        public void CreateProject()
        {
            var createUserResponse = new Client().CreateProject(
                new CreateProjectRequest
                {
                    Name = "TestName",
                });

            Assert.IsNotNull(createUserResponse.Identifier);
            Assert.IsTrue(createUserResponse.Type == CreateProjectResponseType.Success);
        }
    }
}
