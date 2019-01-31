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
            SetUpBuiltInAccounts();
        }

        private static void SetUpBuiltInAccounts()
        {
            var client = new Client();

            var admin = client.UserGet1(new UserGet1Request
            { SearchKeyword = "admin@keeper.com" })?.Items?.SingleOrDefault();

            if (admin == null)
                client.UserCreate(new UserCreateRequest
                {
                    Email = "admin@keeper.com",
                    Group = UserGroupType.Administrator,
                    Password = "zaq1@WSX"
                });

            var projectManager = client.UserGet1(new UserGet1Request
            { SearchKeyword = "pm@keeper.com" })?.Items?.SingleOrDefault();

            if (projectManager == null)
                client.UserCreate(new UserCreateRequest
                {
                    Email = "pm@keeper.com",
                    Group = UserGroupType.ProjectManager,
                    Password = "zaq1@WSX"
                });

            var projectManager2 = client.UserGet1(new UserGet1Request
            { SearchKeyword = "worker@keeper.com" })?.Items?.SingleOrDefault();

            if (projectManager2 == null)
                client.UserCreate(new UserCreateRequest
                {
                    Email = "worker@keeper.com",
                    Group = UserGroupType.Worker,
                    Password = "zaq1@WSX"
                });
        }
    }
}
