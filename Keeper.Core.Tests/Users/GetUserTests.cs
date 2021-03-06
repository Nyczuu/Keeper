﻿using Keeper.CoreContract.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Keeper.Core.Tests.Users
{
    [TestClass]
    public class GetUserTests : BaseUserTests
    {
        [TestMethod]
        public void GetUser()
        {
            var testEmail = GeneratePseudoRandomTestEmail();
            var createUserResponse = _client.UserCreate(
                new UserCreateRequest
                {
                    Email = testEmail,
                    Password = _testPassword,
                    Group = UserGroupType.Worker,
                });

            var getUserResponse = _client.UserGet1(
                new UserGet1Request
                {
                    UsersIdentifiers = new int[]
                    { createUserResponse.Identifier.Value }
                });

            Assert.IsTrue(getUserResponse.Items.Count() == 1);
            Assert.IsTrue(getUserResponse.Items.Single().Identifier == createUserResponse.Identifier.Value);
            Assert.IsTrue(getUserResponse.Items.Single().Email.ToLower() == testEmail.ToLower());
            Assert.IsTrue(getUserResponse.Items.Single().Group == UserGroupType.Worker);
        }

        [TestMethod]
        public void GetUser_ByEmail()
        {
            var testEmail = GeneratePseudoRandomTestEmail();
            var createUserResponse = _client.UserCreate(
                new UserCreateRequest { Email = testEmail, Password = _testPassword });

            var getUserResponse = _client.UserGet1(
                new UserGet1Request
                {
                    SearchKeyword = testEmail
                });

            Assert.IsTrue(getUserResponse.Items.FirstOrDefault().Identifier == createUserResponse.Identifier.Value);
            Assert.IsTrue(getUserResponse.Items.FirstOrDefault().Email.ToLower() == testEmail.ToLower());
        }
    }
}
