﻿using Keeper.CoreContract.Users;

namespace Keeper.WPF.Admin
{
    class UserListItemModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public UserGroupType Group { get; set; }
    }
}
