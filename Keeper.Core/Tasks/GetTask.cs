using System.Linq;
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

                    if (request.ProjectIdentifiers != null && request.ProjectIdentifiers.Any())
                        query = query.Where(aTask => request.ProjectIdentifiers.Contains(aTask.ProjectIdentifier));

                    if (!string.IsNullOrWhiteSpace(request.SearchKeyword))
                        query = query.Where(aTask => aTask.Name.ToLower().Contains(request.SearchKeyword.ToLower().Trim()));

                    if (request.Status != null)
                        query = query.Where(aTast => aTast.Status == request.Status);

                    Response = new GetTaskResponse
                    {
                        Items = query.Select(aTask => new GetTaskResponseItem
                        {
                            Identifier = aTask.Identifier,
                            Name = aTask.Name,
                            Description = aTask.Description,
                            ProjectIdentifier = aTask.ProjectIdentifier,
                            Status = aTask.Status,
                        }).ToArray(),
                    };
                }
            }
        }
    }
}
