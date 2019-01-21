using Keeper.CoreContract.Projects;
using System;

namespace Keeper.Core.Tests.Tasks
{
    public class BaseTaskTests : BaseTests
    {
        protected int _projectIdentifier;

        protected string _testDescription
        {
            get
            {
                return "Lorem ipsum dolor sit amet, consectetur adipiscing elit,"
                +"sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. "
                +"Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi "
                +"ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit "
                +"in voluptate velit esse cillum dolore eu fugiat nulla pariatur. "
                +"Excepteur sint occaecat cupidatat non proident, sunt in culpa qui "
                +"officia deserunt mollit anim id est laborum.";
            }
        }

        public BaseTaskTests()
        {
            _projectIdentifier = new Client().CreateProject(
                new CreateProjectRequest { Name = _testName }).Identifier.Value;
        }
    }
}
