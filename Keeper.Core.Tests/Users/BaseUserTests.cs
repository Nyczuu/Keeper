using System;

namespace Keeper.Core.Tests.Users
{
    public class BaseUserTests : BaseTests
    {
        private readonly string _testEmailDomain = "@test.pl";

        protected string _testPassword { get; private set; }
        protected string _testEmail { get { return GeneratePseudoRandomTestEmail(); } }

        public BaseUserTests()
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