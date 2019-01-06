using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keeper.CoreContract.Projects;
using Keeper.Data.Users;

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

            Name = request.Name;
        }
    }
}
