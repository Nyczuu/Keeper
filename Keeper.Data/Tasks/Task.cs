using System;
using Keeper.CoreContract.Tasks;
using Keeper.Data.Projects;

namespace Keeper.Data.Tasks
{
    public class Task : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ProjectIdentifier { get; private set; }
        public TaskStatus Status { get; private set; }

        public virtual Project Project { get; set; }

        public void Set(CreateTaskRequest request)
        {
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;

            if (request.Name != null)
                Name = request.Name.Trim();

            if (request.Description != null)
                Description = request.Description.Trim();

            ProjectIdentifier = request.ProjectIdentifier;
        }
    }
}
