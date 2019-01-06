using System;

namespace Keeper.Core.Tests.Users
{
    public class BaseUsersTests : BaseTests
    {
        private readonly string _testEmailDomain = "@test.pl";

        protected string _testPassword { get; private set; }
        protected string _testEmail { get { return GeneratePseudoRandomTestEmail(); } }

        public BaseUsersTests()
        {
            _testPassword = "testPassword123!";
        }

        private string GeneratePseudoRandomTestEmail()
        {
            Random random = new Random();
            return $"test{random.Next(10000)}{_testEmailDomain}";
        }
    }
}