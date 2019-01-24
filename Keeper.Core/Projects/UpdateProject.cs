using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Keeper.CoreContract.Projects;
using Keeper.Data;

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
                    var project = dbContext.Projects.SingleOrDefault(aProject
                        => aProject.Identifier == request.ProjectsIdentifier);

                    if (project == null)
                    {
                        Response = new UpdateProjectResponse
                        { Type = UpdateProjectResponseType.ProjectDoesNotExist};
                        return;
                    }
                    else
                    {
                        project.Set(request);
                        dbContext.SaveChanges();
                        Response = new UpdateProjectResponse
                        {
                            Type = UpdateProjectResponseType.Success
                        };
                        return;
                    }
                }
            }
        }
    }
}