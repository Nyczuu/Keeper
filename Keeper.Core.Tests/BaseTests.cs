using Keeper.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keeper.Core.Tests
{
    [TestClass()]
    public class BaseTests
    {
        protected Client _client { get; private set; }

        public BaseTests()
        {
            _client = new Client();
        }

        [AssemblyInitialize]
        public static void Cleanup(TestContext testContext)
        {
            //Warning: order of these commands actually matters!
            var dbContext = new ApplicationDbContext();
            dbContext.UserSession.RemoveRange(dbContext.UserSession);
            dbContext.Users.RemoveRange(dbContext.Users);
            dbContext.Tasks.RemoveRange(dbContext.Tasks);
            dbContext.Projects.RemoveRange(dbContext.Projects);
        }
    }
}
