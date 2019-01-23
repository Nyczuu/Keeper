using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keeper.Data;
using Keeper.CoreContract.Tasks;

namespace Keeper.Core.Tasks
{
    public class GetTask
    {
        public GetTaskResponse Response { get; private set; } 

        public GetTask(GetTaskRequest request)
        {
            if (request != null)
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var query = dbContext.Tasks.AsQueryable();

                    if (request.TaskIdentifiers != null && request.TaskIdentifiers.Any())
                        query = query.Where(aTask => request.TaskIdentifiers.Contains(aTask.Identifier));

                    Response = new GetTaskResponse
                    {
                        Items = query.Select(aTask => new GetTaskResponseItem
                        {
                            Identifier = aTask.Identifier,
                            Name = aTask.Name,
                            Description = aTask.Description,
                            ProjectIdentifier = aTask.ProjectIdentifier
                        }).ToArray(),
                    };



                }

            }
        }
    }
}
