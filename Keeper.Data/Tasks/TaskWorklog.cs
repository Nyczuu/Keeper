using Keeper.CoreContract.Tasks;
using Keeper.Data.Users;
using System;

namespace Keeper.Data.Tasks
{
    public class TaskWorklog : BaseEntity
    {
        public int UserIdentifier { get; private set; }
        public int TaskIdentifier { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? FinishDate { get; private set; }

        public virtual User User { get; private set; }
        public virtual Task Task { get; private set; }

        public void Set(CreateTaskWorklogRequest request)
        {
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;

            UserIdentifier = request.UserIdentifier;
            TaskIdentifier = request.TaskIdentifier;
            StartDate = request.StartDate;
            FinishDate = request.FinishDate;
        }

        public void Set(StartTaskRequest request)
        {
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;

            UserIdentifier = request.UserIdentifier;
            TaskIdentifier = request.TaskIdentifier;
            StartDate = DateTime.Now;
        }
    }
}
