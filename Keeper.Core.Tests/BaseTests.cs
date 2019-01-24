using Keeper.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Keeper.Core.Tests
{
    [TestClass()]
    public class BaseTests
    {
        protected Client _client { get; private set; }
        protected string _testName { get { return GeneratePseudoRandomProjectName(); } }

        public BaseTests()
        {
            _client = new Client();
        }

        [AssemblyInitialize]
        public static void Cleanup(TestContext testContext)
        {
            //Warning: order of these commands actually matters!
            var dbContext = new ApplicationDbContext();
            dbContext.UserSessions.RemoveRange(dbContext.UserSessions);
            dbContext.Users.RemoveRange(dbContext.Users);
            dbContext.Tasks.RemoveRange(dbContext.Tasks);
            dbContext.Projects.RemoveRange(dbContext.Projects);
        }

        private string GeneratePseudoRandomProjectName()
        {
            Random random = new Random();
            return $"TestName{random.Next(10000)}";
        }
    }
}
