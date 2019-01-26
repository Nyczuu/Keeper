﻿using Keeper.CoreContract.Projects;
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
            var createProjectResponse = _client.CreateProject(
                 new CreateProjectRequest { Name = GeneratePseudoRandomName<Project>()});

            var deleteProjectResponse = _client.DeleteProject(
                new DeleteProjectRequest { Identifiers = new int[] { createProjectResponse.Identifier.Value } });

            Assert.IsNotNull(deleteProjectResponse);
        }
    }
}
