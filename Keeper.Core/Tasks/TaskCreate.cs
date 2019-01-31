using Keeper.CoreContract.Tasks;
using Keeper.Data;
using Keeper.Data.Tasks;
using System.Linq;

namespace Keeper.Core.Tasks
{
    public class TaskCreate
    {
        public TaskCreateResponse Response { get; private set; }

        public TaskCreate(TaskCreateRequest request)
        {
            if (request != null)
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    Response = new TaskCreateResponse
                    { Type = TaskCreateResponseType.NameEmpty };
                    return;
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    var project = dbContext.Projects.SingleOrDefault(aProject => aProject.Identifier == request.ProjectIdentifier);

                    if (project == null)
                    {
                        Response = new TaskCreateResponse
                        { Type = TaskCreateResponseType.ProjectDoesNotExist };
                        return;
                    }

                    if (project.Tasks.Any(aTask => aTask.Name.Trim().ToLower() == request.Name.Trim().ToLower()))
                    {
                        Response = new TaskCreateResponse
                        { Type = TaskCreateResponseType.NameExists };
                        return;
                    }

                    project.Set(request);
                    dbContext.SaveChanges();

                    var task = new Task();
                    task.Set(request, $"{project.Key}-{project.TasksCreatedTotal}");
                    dbContext.Tasks.Add(task);
                    dbContext.SaveChanges();

                    Response = new TaskCreateResponse
                    {
                        Identifier = task.Identifier,
                        Type = TaskCreateResponseType.Success
                    };
                }
            }
        }
    }
}