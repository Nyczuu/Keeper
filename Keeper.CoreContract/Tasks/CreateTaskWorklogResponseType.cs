namespace Keeper.CoreContract.Tasks
{
    public enum CreateTaskWorklogResponseType
    {
        TaskDoesNotExist,
        UserDoesNotExist,
        StartAndFinishPeriodNotValid,
        StartAndFinishPeriodLessThanOneMinute,
        Success,
    }
}
