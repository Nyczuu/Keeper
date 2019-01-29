using System;
using System.Collections;
using System.Collections.Generic;
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

        public virtual Project Project { get; private set; }
        public virtual ICollection<TaskComment> Comments { get; private set; }
        public virtual ICollection<TaskWorklog> Worklogs { get; private set; }

        public void Set(CreateTaskRequest request)
        {
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;
            Status = TaskStatus.Open;
            ProjectIdentifier = request.ProjectIdentifier;

            if (request.Name != null)
                Name = request.Name.Trim();

            if (request.Description != null)
                Description = request.Description.Trim();
        }

        public void Set(UpdateTaskRequest request)
        {
            UpdatedOnUtc = DateTime.UtcNow;

            if (request.Name != null)
                Name = request.Name.Trim();
            if (request.Description != null)
                Description = request.Description.Trim();

            ProjectIdentifier = request.ProjectIdentifier;
        }

        public void Set(StartTaskRequest request)
        {
            UpdatedOnUtc = DateTime.UtcNow;

            Status = TaskStatus.InProgress;
        }
    }
}
