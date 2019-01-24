using Keeper.Data.Tasks;
using Keeper.Data.Users;
using System;

namespace Keeper.Data.Worklogs
{
    public class Worklog : BaseEntity
    {
        public int UserIdentifier { get; private set; }
        public int TaskIdentifier { get; private set; }
        public DateTime? FinishedOnUtc { get; private set; }

        public virtual User User { get; private set; }
        public virtual Task Task { get; private set; }
    }
}
