namespace Keeper.CoreContract.Tasks
{
    public class TaskStartResponse
    {
        public TaskStartResponseType Type;
        public int? ConflictingTaskId;
        public string ConflictingTaskName;
    }
}
