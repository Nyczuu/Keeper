using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.CoreContract.Users
{
    public class UserRemoveFromProjectRequest
    {
        public int ProjectIdentifier;
        public int[] UsersIdentifiers;
    }
}
