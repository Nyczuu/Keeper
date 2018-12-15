using Keeper.CoreContract.Users;
using System;

namespace Keeper.Data.Users
{
    public class User : BaseEntity
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserGroupType GroupType { get; private set; }

        public void Set(CreateUserRequest request)
        {
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;

            Email = request.Email.ToLower();
            Password = request.Password;
            GroupType = request.Group;
        }
    }
}
