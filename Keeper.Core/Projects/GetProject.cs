using Keeper.CoreContract.Projects;
using Keeper.Data;
using System.Linq;

namespace Keeper.Core.Projects
{
    public class GetProject
    {
        public GetProjectResponse Response { get; private set; }

        public GetProject(GetProjectRequest request)
        {
            if (request != null)
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var query = dbContext.Projects.AsQueryable();

                    if (request.ProjectsIdentifiers != null && request.ProjectsIdentifiers.Any())
                        query = query.Where(aProject => request.ProjectsIdentifiers.Contains(aProject.Identifier));

                    if (!string.IsNullOrWhiteSpace(request.SearchKeyword))
                        query = query.Where(aProject => aProject.Name.ToLower().Contains(request.SearchKeyword.ToLower()));

                    Response = new GetProjectResponse
                    {
                        Items = query.Select(aProject => new GetProjectResponseItem
                        {
                            Identifier = aProject.Identifier,
                            Name = aProject.Name,
                            TasksCount = aProject.Tasks.Count(),
                        }).ToArray(),
                    };
                }
            }
        }
    }
}
