using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.CoreContract.Users
{
    public class RemoveUsersFromProjectRequest
    {
        public int ProjectIdentifier;
        public int[] UsersIdentifiers;
    }
}
