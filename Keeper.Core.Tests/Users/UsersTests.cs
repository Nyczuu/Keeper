using Keeper.CoreContract.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Keeper.Core.Tests.Users
{
    [TestClass()]
    public class UsersTests
    {
        private readonly Client _client;
        private readonly string _testEmail;
        private readonly string _testPassword;

        public UsersTests()
        {
            _client = new Client();
            _testEmail = "test@email.com";
            _testPassword = "testPassword123";
        }

        [TestMethod()]
        public void DeleteUser()
        {
            var createUserResponse = _client.CreateUser(
                new CreateUserRequest { Email = _testEmail, Password = _testPassword });

            var deleteUserResponse = _client.DeleteUser(
                new DeleteUserRequest { Identifiers = new int[] { createUserResponse.Identifier.Value } });

            Assert.IsNotNull(deleteUserResponse);
        }

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

            _client.DeleteUser(
               new DeleteUserRequest { Identifiers = new int[] { createUserResponse.Identifier.Value } });
        }

        [TestMethod()]
        public void GetUser()
        {
            var createUserResponse = _client.CreateUser(
                new CreateUserRequest
                {
                    Email = _testEmail,
                    Password = _testPassword,
                    Group = UserGroupType.Worker,
                });

            var getUserResponse = _client.GetUser(
                new GetUserRequest
                {
                    UsersIdentifiers = new int[] 
                    { createUserResponse.Identifier.Value }
                });

            Assert.IsTrue(getUserResponse.Items.Count() == 1);
            Assert.IsTrue(getUserResponse.Items.Single().Identifier == createUserResponse.Identifier.Value);
            Assert.IsTrue(getUserResponse.Items.Single().Email == _testEmail);
            Assert.IsTrue(getUserResponse.Items.Single().Group == UserGroupType.Worker);

            _client.DeleteUser(
               new DeleteUserRequest { Identifiers = new int[] { createUserResponse.Identifier.Value } });
        }

        [DataTestMethod()]
        [DataRow("test@")]
        [DataRow("test@email.com")]
        [DataRow("t")]
        public void GetUser_SearchByEmail(string keyword)
        {
            var createUserResponse = _client.CreateUser(
                new CreateUserRequest { Email = _testEmail, Password = _testPassword });

            var getUserResponse = _client.GetUser(
                new GetUserRequest
                {
                    SearchKeyword = keyword
                });

            Assert.IsTrue(getUserResponse.Items.Count() == 1);
            Assert.IsTrue(getUserResponse.Items.Single().Identifier == createUserResponse.Identifier.Value);
            Assert.IsTrue(getUserResponse.Items.Single().Email == _testEmail);

            _client.DeleteUser(
               new DeleteUserRequest { Identifiers = new int[] { createUserResponse.Identifier.Value } });
        }
    }
}