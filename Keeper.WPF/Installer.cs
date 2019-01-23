using Keeper.Core;
using Keeper.CoreContract.Users;
using System.Linq;

namespace Keeper.WPF
{
    public static class Installer
    {
        public static void Run()
        {
            //Installation steps here
            SetUpBuiltInAdministratorAccount();
        }

        private static void SetUpBuiltInAdministratorAccount()
        {
            var client = new Client();

            var admin = client.GetUser(new GetUserRequest
            { SearchKeyword = "admin@keeper.com" })?.Items?.SingleOrDefault();

            if (admin == null)
                client.CreateUser(new CreateUserRequest
                {
                    Email = "admin@keeper.com",
                    Group = UserGroupType.Administrator,
                    Password = "zaq1@WSX"
                });
        }
    }
}
