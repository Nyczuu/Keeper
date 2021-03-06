﻿using Keeper.CoreContract.Projects;
using Keeper.Data.Projects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Keeper.Core.Tests.Projects
{
    [TestClass]
    public class GetProjectTests : BaseProjectTests
    {
        [TestMethod]
        public void GetProject()
        {
            var testName = GeneratePseudoRandomName<Project>();
            var createProjectResponse = _client.ProjectCreate(
                new ProjectCreateRequest { Name = testName });

            var getProjectResponse = _client.ProjectGet1(
                new ProjectGet1Request
                {
                    ProjectsIdentifiers = new int[]
                    { createProjectResponse.Identifier.Value }
                });

            Assert.IsTrue(getProjectResponse.Items.Count() == 1);
            Assert.IsTrue(getProjectResponse.Items.Single().Identifier == createProjectResponse.Identifier.Value);
            Assert.IsTrue(getProjectResponse.Items.Single().Name == testName);
        }

        [TestMethod]
        public void GetProject_ByName()
        {
            var testName = GeneratePseudoRandomName<Project>();

            var createProjectResponse = _client.ProjectCreate(
                new ProjectCreateRequest { Name = testName });

            var getProjectResponse = _client.ProjectGet1(
                new ProjectGet1Request { SearchKeyword = testName });

            Assert.IsTrue(getProjectResponse.Items.FirstOrDefault().Identifier == createProjectResponse.Identifier.Value);
            Assert.IsTrue(getProjectResponse.Items.FirstOrDefault().Name == testName);
        }
    }
}