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
            Assert.IsTrue(createUserResponse.Type
                == CreateUserResponseType.Success);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("      ")]
        [DataRow("testmail.pl")]
        public void CreateUser_EmailNotValid(string email)
        {
            var createUserResponse = _client.CreateUser(
                new CreateUserRequest
                {
                    Email = email,
                    Password = _testPassword
                });

            Assert.IsTrue(createUserResponse.Type
                == CreateUserResponseType.EmailNotValid);
        }

        [DataTestMethod()]
        [DataRow("EXISTINGTESTUSER@test.pl")]
        [DataRow("existingtestuser@test.pl")]
        public void CreateUser_EmailExists(string email)
        {
            var createFirstUserResponse = _client.CreateUser(
                new CreateUserRequest
                {
                    Email = "ExistingTestUser@test.pl",
                    Password = _testPassword
                });

            var createSameEmailUserResponse = _client.CreateUser(
                new CreateUserRequest
                {
                    Email = email,
                    Password = _testPassword
                });

            Assert.IsTrue(createSameEmailUserResponse.Type
                == CreateUserResponseType.EmailExists);
        }
    }
}
