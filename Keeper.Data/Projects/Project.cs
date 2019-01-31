using Keeper.CoreContract.Projects;
using Keeper.CoreContract.Tasks;
using Keeper.Data.Tasks;
using Keeper.Data.Users;
using System;
using System.Collections.Generic;

namespace Keeper.Data.Projects
{
    public class Project : BaseEntity
    {
        public string Name { get; private set; }
        public string Key { get; private set; }
        public int CreatorIdentifier { get; private set; }
        public int TasksCreatedTotal { get; private set; }

        public virtual ICollection<User> Users { get; private set; }
        public virtual ICollection<Task> Tasks { get; private set; }

        public void Set(CreateProjectRequest request, string key)
        {
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;

            CreatorIdentifier = request.CreatorIdentifier;

            if (request.Name != null)
                Name = request.Name.Trim();

            if (key != null)
                Key = key.ToUpper().Trim();
        }

        public void Set(UpdateProjectRequest request)
        {
            UpdatedOnUtc = DateTime.UtcNow;

            if (request.Name != null)
                Name = request.Name.Trim();
        }

        public void Set(CreateTaskRequest request)
        {
            TasksCreatedTotal++;
        }
    }
}
