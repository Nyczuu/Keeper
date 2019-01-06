using Keeper.CoreContract.Projects;
using Keeper.Data.Users;
using System;
using System.Collections.Generic;

namespace Keeper.Data.Projects
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public void Set(CreateProjectRequest request)
        {
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;

            if (request.Name != null)
                Name = request.Name.Trim();
        }
    }
}
