using Keeper.CoreContract.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keeper.Core.Tests.Users
{
    [TestClass]
    public class DeleteUserTests : BaseUserTests
    {
        [TestMethod]
        public void DeleteUser()
        {
            var createUserResponse = _client.UserCreate(
                new UserCreateRequest
                {
                    Email = GeneratePseudoRandomTestEmail(),
                    Password = _testPassword
                });

            var deleteUserResponse = _client.UserDelete(
                new UserDeleteRequest { Identifiers = new int[] { createUserResponse.Identifier.Value } });

            Assert.IsNotNull(deleteUserResponse);
        }
    }
}
