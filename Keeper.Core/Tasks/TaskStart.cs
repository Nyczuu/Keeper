using Keeper.CoreContract.Tasks;
using Keeper.Data;
using Keeper.Data.Tasks;
using System.Linq;

namespace Keeper.Core.Tasks
{
    public class TaskStart
    {
        public TaskStartResponse Response { get; private set; }

        public TaskStart(TaskStartRequest request)
        {
            if (request != null)
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var task = dbContext.Tasks.SingleOrDefault(aTask => aTask.Identifier == request.TaskIdentifier);

                    if (task == null)
                    {
                        Response = new TaskStartResponse
                        { Type = TaskStartResponseType.TaskDoesNotExist };
                        return;
                    }

                    var user = dbContext.Users.SingleOrDefault(aUser => aUser.Identifier == request.UserIdentifier);

                    if (user == null)
                    {
                        Response = new TaskStartResponse
                        { Type = TaskStartResponseType.UserDoesNotExist };
                        return;
                    }

                    var conflictingTask = task.Worklogs.SingleOrDefault(aWorklog 
                        => aWorklog.FinishDate == null && aWorklog.UserIdentifier == request.UserIdentifier);

                    if (conflictingTask != null)
                    {
                        Response = new TaskStartResponse
                        {
                            Type = TaskStartResponseType.ConflictingTaskExists,
                            ConflictingTaskId = conflictingTask.Task.Identifier,
                            ConflictingTaskName = conflictingTask.Task.Name,
                        };
                        return;
                    }

                    var worklog = new TaskWorklog();
                    worklog.Set(request);
                    dbContext.TaskWorklogs.Add(worklog);
                    dbContext.SaveChanges();

                    //Set task to in progress.
                    task.Set(request);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}