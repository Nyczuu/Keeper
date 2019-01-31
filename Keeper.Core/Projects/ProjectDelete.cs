using System.Linq;
using Keeper.CoreContract.Projects;
using Keeper.Data;

namespace Keeper.Core.Projects
{
    class ProjectDelete
    {
        public ProjectDeleteResponse Response { get; private set; }

        public ProjectDelete(ProjectDeleteRequest request)
        {
            if (request != null && request.Identifiers != null && request.Identifiers.Any())
            {
                using (var dbContext = new ApplicationDbContext())
                {                
                    var projectsToDelete = dbContext.Projects.Where(aProject
                        => request.Identifiers.Contains(aProject.Identifier));

                    dbContext.Projects.RemoveRange(projectsToDelete);
                    dbContext.SaveChanges();
                }

                Response = new ProjectDeleteResponse();
            }
        }
    }
}
