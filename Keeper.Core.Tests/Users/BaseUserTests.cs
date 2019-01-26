using Keeper.Data.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Keeper.Core.Tests.Users
{
    [TestClass]
    public class BaseUserTests : BaseTests
    {
        private string _testEmailDomain;
        protected string _testPassword;

        [TestInitialize]
        public void Setup()
        {
            _testEmailDomain = "@test.pl";
            _testPassword = "testPassword123!";
        }

        public string GeneratePseudoRandomTestEmail()
        {
            return $"test{GeneratePseudoRandomName<User>()}{_testEmailDomain}";
        }
    }
}