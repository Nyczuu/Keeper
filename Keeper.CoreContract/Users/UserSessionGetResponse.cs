using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.CoreContract.Users
{
    public class UserSessionGetResponse
    {
        public Guid SessionKey;
        public int UserIdentifier;
        public string UserEmail;
        public UserGroupType UserGroupType;
    }
}
