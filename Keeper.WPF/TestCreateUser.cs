using Keeper.Core;
using Keeper.CoreContract.Users;
using System;

namespace Keeper.WPF
{
    public class TestCreateUser
    {
        public TestCreateUser()
        {
            var user = new { Name = "Test", Password = "Test" };

            var response = new Client().CreateUser(
                new CreateUserRequest { Email = user.Name, Password = user.Password });

            if (!response.Success)
                Console.WriteLine("Nie udalo sie");

        }
    }
}
