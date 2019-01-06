﻿using Keeper.CoreContract.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keeper.Core.Tests.Users
{
    [TestClass()]
    public class DeleteUserTests : BaseUsersTests
    {
        [TestMethod()]
        public void DeleteUser()
        {
            var createUserResponse = _client.CreateUser(
                new CreateUserRequest { Email = _testEmail, Password = _testPassword });

            var deleteUserResponse = _client.DeleteUser(
                new DeleteUserRequest { Identifiers = new int[] { createUserResponse.Identifier.Value } });

            Assert.IsNotNull(deleteUserResponse);
        }
    }
}