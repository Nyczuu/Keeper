namespace Keeper.CoreContract.Tasks
{
    public enum TaskWorklogCreateResponseType
    {
        TaskDoesNotExist,
        UserDoesNotExist,
        StartAndFinishPeriodNotValid,
        StartAndFinishPeriodLessThanOneMinute,
        Success,
    }
}
