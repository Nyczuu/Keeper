using System;
using System.Collections;
using System.Collections.Generic;
using Keeper.CoreContract.Tasks;
using Keeper.Data.Projects;
using Keeper.Data.Users;

namespace Keeper.Data.Tasks
{
    public class Task : BaseEntity
    {
        public string Name { get; private set; }
        public string Number { get; private set; }
        public string Description { get; private set; }
        public int ProjectIdentifier { get; private set; }
        public int CreatorIdentifier { get; private set; }
        public int? AssigneeIdentifier { get; private set; }
        public TaskStatus Status { get; private set; }

        public virtual Project Project { get; private set; }
        public virtual ICollection<TaskComment> Comments { get; private set; }
        public virtual ICollection<TaskWorklog> Worklogs { get; private set; }

        public void Set(TaskCreateRequest request, string number)
        {
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;
            Status = TaskStatus.Open;
            ProjectIdentifier = request.ProjectIdentifier;
            CreatorIdentifier = request.CreatorIdentifier;
            AssigneeIdentifier = request.AssigneeIdentifier;

            if (request.Name != null)
                Name = request.Name.Trim();

            if (number != null)
                Number = number.ToUpper().Trim();

            if (request.Description != null)
                Description = request.Description.Trim();
        }

        public void Set(TaskUpdateRequest request)
        {
            UpdatedOnUtc = DateTime.UtcNow;

            if (request.Name != null)
                Name = request.Name.Trim();
            if (request.Description != null)
                Description = request.Description.Trim();

            ProjectIdentifier = request.ProjectIdentifier;
        }

        public void Set(TaskStartRequest request)
        {
            UpdatedOnUtc = DateTime.UtcNow;

            Status = TaskStatus.InProgress;
        }
    }
}
