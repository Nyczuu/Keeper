using Keeper.Core;
using Keeper.CoreContract.Users;

namespace Keeper.WPF
{
    public class TestCreateUser
    {
        public TestCreateUser()
        {
            var client = new Client().CreateUser(
                new CreateUserRequest { Email = "test", Password = "test" });
        }
    }
}
