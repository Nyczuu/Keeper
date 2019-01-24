using Keeper.Data.Users;

namespace Keeper.Data.Tasks
{
    public class TaskComment : BaseEntity
    {
        public int TaskIdentifier { get; private set; }
        public int UserIdentifier { get; private set; }

        public virtual Task Task { get; private set; }
        public virtual User User { get; private set; }
    }
}
