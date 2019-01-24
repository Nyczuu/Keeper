using Keeper.CoreContract.Tasks;
using Keeper.Data;
using Keeper.Data.Tasks;
using System.Linq;

namespace Keeper.Core.Tasks
{
    public class CreateTask
    {
        public CreateTaskResponse Response { get; private set; }

        public CreateTask(CreateTaskRequest request)
        {
            if (request != null)
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                    Response = new CreateTaskResponse
                    { Type = CreateTaskResponseType.NameEmpty };

                else
                {
                    using (var dbContext = new ApplicationDbContext())
                    {
                        ;

                        if (project == null)
                            Response = new CreateTaskResponse
                            { Type = CreateTaskResponseType.ProjectDoNotExists };

                        else
                        {
                            if (project.Tasks.Any(aTask
                                 => aTask.Name.Trim().ToLower()
                                 == request.Name.Trim().ToLower()))
                                Response = new CreateTaskResponse
                                { Type = CreateTaskResponseType.NameExists };

                            else
                            {
                                var task = new Task();
                                task.Set(request);
                                dbContext.Tasks.Add(task);
                                dbContext.SaveChanges();

                                Response = new CreateTaskResponse
                                {
                                    Identifier = task.Identifier,
                                    Type = CreateTaskResponseType.Success
                                };
                            }
                        }
                    }
                }
            }
        }
    }
}
