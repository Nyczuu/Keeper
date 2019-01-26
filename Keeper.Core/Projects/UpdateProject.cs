using Keeper.CoreContract.Projects;
using Keeper.Data;
using System.Linq;

namespace Keeper.Core.Projects
{
    public class UpdateProject
    {
        public UpdateProjectResponse Response { get; private set; }

        public UpdateProject(UpdateProjectRequest request)
        {
            if (request != null)
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var project = dbContext.Projects.SingleOrDefault(aProject => aProject.Identifier == request.ProjectsIdentifier);

                    if (project == null)
                    {
                        Response = new UpdateProjectResponse
                        { Type = UpdateProjectResponseType.ProjectDoesNotExist };
                        return;
                    }

                    project.Set(request);
                    dbContext.SaveChanges();
                    Response = new UpdateProjectResponse
                    { Type = UpdateProjectResponseType.Success };
                }
            }
        }
    }
}