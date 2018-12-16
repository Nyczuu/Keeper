using Keeper.CoreContract.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keeper.Core.Tests.Users
{
    [TestClass()]
    public class CreateUserTests : BaseUsersTests
    {
        [TestMethod()]
        public void CreateUser()
        {
            var createUserResponse = _client.CreateUser(
                new CreateUserRequest
                {
                    Email = _testEmail,
                    Password = _testPassword,
                    Group = UserGroupType.Worker,
                });

            Assert.IsNotNull(createUserResponse.Identifier);
            Assert.IsTrue(createUserResponse.Success);
        }
    }
}
