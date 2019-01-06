using Keeper.CoreContract.Users;
using Keeper.Data.Projects;
using System;
using System.Collections.Generic;

namespace Keeper.Data.Users
{
    public class User : BaseEntity
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserGroupType GroupType { get; private set; }

        public virtual ICollection<Project> Projects { get; private set; }

        public void Set(CreateUserRequest request)
        {
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;

            if (request.Email != null)
                Email = request.Email.ToLower().Trim();

            Password = request.Password;
            GroupType = request.Group;
        }
    }
}
