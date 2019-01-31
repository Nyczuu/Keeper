using Keeper.CoreContract.Projects;
using Keeper.Data;
using System.Linq;

namespace Keeper.Core.Projects
{
    public class ProjectUpdate
    {
        public ProjectUpdateResponse Response { get; private set; }

        public ProjectUpdate(ProjectUpdateRequest request)
        {
            if (request != null)
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var project = dbContext.Projects.SingleOrDefault(aProject => aProject.Identifier == request.ProjectsIdentifier);

                    if (project == null)
                    {
                        Response = new ProjectUpdateResponse
                        { Type = ProjectUpdateResponseType.ProjectDoesNotExist };
                        return;
                    }

                    project.Set(request);
                    dbContext.SaveChanges();
                    Response = new ProjectUpdateResponse
                    { Type = ProjectUpdateResponseType.Success };
                }
            }
        }
    }
}