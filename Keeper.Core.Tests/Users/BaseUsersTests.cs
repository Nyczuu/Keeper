using System;

namespace Keeper.Core.Tests.Users
{
    public class BaseUsersTests : BaseTests
    {
        private readonly string _testEmailDomain = "@test.pl";

        protected Client _client { get; private set; }
        protected string _testPassword { get; private set; }

        protected string _testEmail { get => GeneratePseudoRandomTestEmail(); }

        public BaseUsersTests()
        {
            _client = new Client();
            _testPassword = "testPassword123";
        }

        private string GeneratePseudoRandomTestEmail()
        {
            Random random = new Random();
            return $"test{random.Next(10000)}{_testEmailDomain}";
        }
    }
}