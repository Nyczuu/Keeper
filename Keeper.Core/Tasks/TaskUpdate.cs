using Keeper.CoreContract.Tasks;
using Keeper.Data;
using System.Linq;

namespace Keeper.Core.Tasks
{
    public class TaskUpdate
    {
        public TaskUpdateResponse Response { get; private set; }

        public TaskUpdate(TaskUpdateRequest request)
        {
            if (request != null)
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var task = dbContext.Tasks.SingleOrDefault(aTask => aTask.Identifier == request.Identifier);
                    var project = dbContext.Projects.SingleOrDefault(aProject => aProject.Identifier == request.ProjectIdentifier);

                    if (task == null)
                    {
                        Response = new TaskUpdateResponse
                        { Type = TaskUpdateResponseType.TaskDoesNotExist };
                        return;
                    }

                    if (project == null)
                    {
                        Response = new TaskUpdateResponse
                        { Type = TaskUpdateResponseType.ProjectDoesNotExist };
                        return;
                    }

                    task.Set(request);
                    dbContext.SaveChanges();
                    Response = new TaskUpdateResponse
                    {
                        Type = TaskUpdateResponseType.Success
                    };
                }
            }
        }
    }
}
