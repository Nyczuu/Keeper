using Keeper.CoreContract.Projects;
using Keeper.Data.Projects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keeper.Core.Tests.Tasks
{
    [TestClass]
    public class BaseTaskTests : BaseTests
    {
        protected int _testProjectIdentifier;
        protected string _testDescription;

        [TestInitialize]
        public void Setup()
        {
            _testProjectIdentifier = new Client().CreateProject(
                new CreateProjectRequest { Name = GeneratePseudoRandomName<Project>() }).Identifier.Value;

            _testDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit,"
                + "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. "
                + "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi "
                + "ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit "
                + "in voluptate velit esse cillum dolore eu fugiat nulla pariatur. "
                + "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui "
                + "officia deserunt mollit anim id est laborum.";
        }
    }
}
