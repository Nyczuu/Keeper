using Keeper.CoreContract.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Keeper.WPF
{
    public class CurrentlyLoggedOnUser
    {
        public CurrentlyLoggedOnUser(GetUserSessionResponse response)
        {
            Email = response.UserEmail;
            Identifier = response.UserIdentifier;
            GroupType = response.UserGroupType;
        }
        public readonly int Identifier;
        public readonly string Email;
        public readonly UserGroupType GroupType;
    }
}
