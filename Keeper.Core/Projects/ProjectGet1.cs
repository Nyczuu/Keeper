using Keeper.CoreContract.Projects;
using Keeper.Data;
using System.Linq;

namespace Keeper.Core.Projects
{
    public class ProjectGet1
    {
        public ProjectGet1Response Response { get; private set; }

        public ProjectGet1(ProjectGet1Request request)
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

                    Response = new ProjectGet1Response
                    {
                        Items = query.Select(aProject => new ProjectGet1ResponseItem
                        {
                            Identifier = aProject.Identifier,
                            Name = aProject.Name,
                            Key = aProject.Key,
                            TasksCount = aProject.Tasks.Count(),
                        }).ToArray(),
                    };
                }
            }
        }
    }
}
