namespace Keeper.CoreContract.Tasks
{
    public enum TaskStartResponseType
    {
        TaskDoesNotExist,
        UserDoesNotExist,
        ConflictingTaskExists,
        Success,
    }
}
