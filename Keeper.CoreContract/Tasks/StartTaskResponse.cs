namespace Keeper.CoreContract.Tasks
{
    public class StartTaskResponse
    {
        public StartTaskResponseType Type;
        public int? ConflictingTaskId;
        public string ConflictingTaskName;
    }
}
