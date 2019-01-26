using Keeper.CoreContract.Tasks;
using Keeper.Data;
using System.Linq;

namespace Keeper.Core.Tasks
{
    public class UpdateTask
    {
        public UpdateTaskResponse Response { get; private set; }

        public UpdateTask(UpdateTaskRequest request)
        {
            if (request != null)
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var task = dbContext.Tasks.SingleOrDefault(aTask => aTask.Identifier == request.Identifier);
                    var project = dbContext.Projects.SingleOrDefault(aProject => aProject.Identifier == request.ProjectIdentifier);

                    if (task == null)
                    {
                        Response = new UpdateTaskResponse
                        { Type = UpdateTaskResponseType.TaskDoesNotExist };
                        return;
                    }

                    if (project == null)
                    {
                        Response = new UpdateTaskResponse
                        { Type = UpdateTaskResponseType.ProjectDoesNotExist };
                        return;
                    }

                    task.Set(request);
                    dbContext.SaveChanges();
                    Response = new UpdateTaskResponse
                    {
                        Type = UpdateTaskResponseType.Success
                    };
                }
            }
        }
    }
}
