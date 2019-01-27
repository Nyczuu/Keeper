using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.CoreContract.Users
{
    public class GetUserRequest
    {
        public int[] UsersIdentifiers;
        public int[] ProjectsIdentifiers;
        public string SearchKeyword;
        public UserGroupType? UserGroup;
    }
}
