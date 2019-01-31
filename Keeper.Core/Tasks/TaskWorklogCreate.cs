using Keeper.CoreContract.Tasks;
using Keeper.Data;
using Keeper.Data.Tasks;
using System.Linq;

namespace Keeper.Core.Tasks
{
    public class TaskWorklogCreate
    {
        public TaskWorklogCreateResponse Response { get; private set; }

        public TaskWorklogCreate(TaskWorklogCreateRequest request)
        {
            if (request != null)
            {
                if (request.StartDate > request.FinishDate)
                {
                    Response = new TaskWorklogCreateResponse
                    { Type = TaskWorklogCreateResponseType.StartAndFinishPeriodNotValid };
                    return;
                }

                if ((request.FinishDate - request.StartDate).TotalMinutes < 1)
                {
                    Response = new TaskWorklogCreateResponse
                    { Type = TaskWorklogCreateResponseType.StartAndFinishPeriodLessThanOneMinute };
                    return;
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    var task = dbContext.Tasks.SingleOrDefault(aTask => aTask.Identifier == request.TaskIdentifier);

                    if (task == null)
                    {
                        Response = new TaskWorklogCreateResponse
                        { Type = TaskWorklogCreateResponseType.TaskDoesNotExist };
                        return;
                    }

                    var user = dbContext.Users.SingleOrDefault(aUser => aUser.Identifier == request.UserIdentifier);

                    if (user == null)
                    {
                        Response = new TaskWorklogCreateResponse
                        { Type = TaskWorklogCreateResponseType.UserDoesNotExist };
                        return;
                    }

                    var worklog = new TaskWorklog();
                    worklog.Set(request);
                    dbContext.TaskWorklogs.Add(worklog);
                    dbContext.SaveChanges();

                    Response = new TaskWorklogCreateResponse
                    { Type = TaskWorklogCreateResponseType.Success };
                }
            }
        }
    }
}