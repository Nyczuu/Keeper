using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keeper.CoreContract.Projects;
using Keeper.Data;


namespace Keeper.Core.Projects
{
    public class DeleteProject
    {
        public DeleteProjectResponse Response { get; private set; }

        public DeleteProject(DeleteProjectRequest Request) {

            if (Request != null) {
                using (var dbContext = new ApplicationDbContext())
                {

                    var ProjectToDelete = dbContext.Projects.Where(aProject
                        => Request.Identifier.Equals(aProject.Identifier));

                    if (ProjectToDelete != null)
                    {
                        dbContext.Projects.RemoveRange(ProjectToDelete);
                        dbContext.SaveChanges();

                        Response = new DeleteProjectResponse
                        {
                            Type = DeleteProjectResponseType.Success,
                        };
                    }

                    else {
                        Response = new DeleteProjectResponse {
                            Type = DeleteProjectResponseType.WrongProjectID,
                        };
                    }
                }
            }
           
        }

    }
}
