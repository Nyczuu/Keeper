using Keeper.CoreContract.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.WPF
{
    public class UserListItemModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public UserGroupType Group { get; set; }
    }
}
