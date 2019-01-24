namespace Keeper.CoreContract.Tasks
{
    public enum StartTaskResponseType
    {
        TaskDoesNotExist,
        UserDoesNotExist,
        ConflictingTaskExists,
        Success,
    }
}
