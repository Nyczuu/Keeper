using System;

namespace Keeper.CoreContract.Tasks
{
    public class CreateTaskWorklogRequest
    {
        public int UserIdentifier;
        public int TaskIdentifier;

        public DateTime StartDate;
        public DateTime FinishDate;
    }
}
