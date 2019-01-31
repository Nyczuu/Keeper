using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.CoreContract.Users
{
    public class UserCreateRequest
    {
        public string Email;
        public string Password;
        public UserGroupType Group = UserGroupType.Worker;
    }
}
