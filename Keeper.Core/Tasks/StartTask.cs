using Keeper.CoreContract.Tasks;
using Keeper.Data;
using Keeper.Data.Tasks;
using System.Linq;

namespace Keeper.Core.Tasks
{
    public class StartTask
    {
        public StartTaskResponse Response { get; private set; }

        public StartTask(StartTaskRequest request)
        {
            if (request != null)
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var task = dbContext.Tasks.SingleOrDefault(aTask => aTask.Identifier == request.TaskIdentifier);

                    if (task == null)
                    {
                        Response = new StartTaskResponse
                        { Type = StartTaskResponseType.TaskDoesNotExist };
                        return;
                    }

                    var user = dbContext.Users.SingleOrDefault(aUser => aUser.Identifier == request.UserIdentifier);

                    if (user == null)
                    {
                        Response = new StartTaskResponse
                        { Type = StartTaskResponseType.UserDoesNotExist };
                        return;
                    }

                    var conflictingTask = task.Worklogs.SingleOrDefault(aWorklog 
                        => aWorklog.FinishDate == null && aWorklog.UserIdentifier == request.UserIdentifier);

                    if (conflictingTask != null)
                    {
                        Response = new StartTaskResponse
                        {
                            Type = StartTaskResponseType.ConflictingTaskExists,
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