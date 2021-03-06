﻿using Keeper.CoreContract.Projects;
using Keeper.CoreContract.Tasks;
using Keeper.Data.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Keeper.Core.Tests.Tasks
{
    [TestClass]
    public class GetTaskTests : BaseTaskTests
    {
        [TestMethod]
        public void GetTask()
        {
            var testName = GeneratePseudoRandomName<Task>();

            var createTaskResponse = _client.TaskCreate(
                new TaskCreateRequest
                {
                    Name = testName,
                    Description = _testDescription,
                    ProjectIdentifier = _testProjectIdentifier,
                });

            var getTaskResponse = _client.TaskGet1(
                new TaskGet1Request
                {
                    TaskIdentifiers = new int[]
                    { createTaskResponse.Identifier.Value }
                });

            Assert.IsTrue(getTaskResponse.Items.Count() == 1);
            Assert.IsTrue(getTaskResponse.Items.Single().Identifier == createTaskResponse.Identifier.Value);
            Assert.IsTrue(getTaskResponse.Items.Single().Name == testName);
            Assert.IsTrue(getTaskResponse.Items.Single().Description == _testDescription);
        }

        [TestMethod]
        public void GetTask_ByProjectIdentifier()
        {
            var testName = GeneratePseudoRandomName<Task>();

            var createTaskResponse = _client.TaskCreate(
                            new TaskCreateRequest
                            {
                                Name = testName,
                                ProjectIdentifier = _testProjectIdentifier,
                            });

            var getTaskResponse= _client.TaskGet1(
                new TaskGet1Request { ProjectIdentifiers = new int[] { _testProjectIdentifier } });

            Assert.IsTrue(getTaskResponse.Items.SingleOrDefault().Identifier == createTaskResponse.Identifier.Value);
            Assert.IsTrue(getTaskResponse.Items.SingleOrDefault().Name == testName);
        }
    }
}
