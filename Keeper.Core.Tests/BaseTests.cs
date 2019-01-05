using Keeper.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keeper.Core.Tests
{
    [TestClass]
    public class BaseTests
    {
        [AssemblyInitialize]
        public static void Cleanup(TestContext testContext)
        {
            var dbContext = new ApplicationDbContext();
            dbContext.UserSession.RemoveRange(dbContext.UserSession);
            dbContext.Users.RemoveRange(dbContext.Users);
        }
    }
}
