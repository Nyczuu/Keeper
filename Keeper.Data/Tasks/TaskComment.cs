using Keeper.CoreContract.Tasks;
using Keeper.Data.Users;

namespace Keeper.Data.Tasks
{
    public class TaskComment : BaseEntity
    {
        public string Content { get; private set; }
        public int TaskIdentifier { get; private set; }
        public int UserIdentifier { get; private set; }

        public virtual Task Task { get; private set; }
        public virtual User User { get; private set; }

        public void Set(CreateTaskCommentRequest request)
        {
            Content = request.Content;
            TaskIdentifier = request.TaskIdentifier;
            UserIdentifier = request.UserIdentifier;
        }
    }
}