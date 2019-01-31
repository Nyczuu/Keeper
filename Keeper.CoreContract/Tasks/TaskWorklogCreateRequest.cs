using System;

namespace Keeper.CoreContract.Tasks
{
    public class TaskWorklogCreateRequest
    {
        public int UserIdentifier;
        public int TaskIdentifier;

        public DateTime StartDate;
        public DateTime FinishDate;
    }
}
