using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Keeper.CoreContract.Tasks;
using Keeper.Data;

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
                    var task = dbContext.Tasks.SingleOrDefault(aTask
                             => aTask.Identifier == request.Identifier);

                    var project = dbContext.Projects.SingleOrDefault(aProject
                             => aProject.Identifier == request.ProjectIdentifier);

                    if (task == null)
                    {
                        Response = new UpdateTaskResponse
                        { Type = UpdateTaskResponseType.TaskDoesNotExist };
                        return;
                    }
                    else if (project == null)
                    {
                        Response = new UpdateTaskResponse
                        { Type = UpdateTaskResponseType.ProjectDoesNotExist };
                        return;
                    }
                    else
                    {
                        task.Set(request);
                        dbContext.SaveChanges();
                        Response = new UpdateTaskResponse
                        {
                            Type = UpdateTaskResponseType.Success
                        };
                        return;
                    }                                        
                }
            }
        }
    }
}
