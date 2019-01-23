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
            SetUpBuiltInProjectManagersAccounts();
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

        private static void SetUpBuiltInProjectManagersAccounts()
        {
            var client = new Client();

            var projectManager = client.GetUser(new GetUserRequest
            { SearchKeyword = "pm@keeper.com" })?.Items?.SingleOrDefault();

            if (projectManager == null)
                client.CreateUser(new CreateUserRequest
                {
                    Email = "pm@keeper.com",
                    Group = UserGroupType.ProjectManager,
                    Password = "zaq1@WSX"
                });

            var projectManager2 = client.GetUser(new GetUserRequest
            { SearchKeyword = "pm2@keeper.com" })?.Items?.SingleOrDefault();

            if (projectManager2 == null)
                client.CreateUser(new CreateUserRequest
                {
                    Email = "pm2@keeper.com",
                    Group = UserGroupType.ProjectManager,
                    Password = "zaq1@WSX"
                });
        }
    }
}
