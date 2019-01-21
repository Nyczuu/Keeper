using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keeper.CoreContract.Projects;
using Keeper.Data;

namespace Keeper.Core.Projects
{
    class DeleteProject
    {
        public DeleteProjectResponse Response { get; private set; }

        public DeleteProject(DeleteProjectRequest request)
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

                Response = new DeleteProjectResponse();

            }

        }
    }
}
