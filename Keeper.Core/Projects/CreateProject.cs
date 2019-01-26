using Keeper.CoreContract.Projects;
using Keeper.Data;
using Keeper.Data.Projects;
using System.Linq;

namespace Keeper.Core.Projects
{
    public class CreateProject
    {
        public CreateProjectResponse Response { get; private set; }

        public CreateProject(CreateProjectRequest request)
        {
            if (request != null)
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    Response = new CreateProjectResponse
                    { Type = CreateProjectResponseType.NameEmpty };
                    return;
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    if (dbContext.Projects.Any(aProject => aProject.Name.ToLower().Trim() == request.Name.ToLower().Trim()))
                    {
                        Response = new CreateProjectResponse
                        { Type = CreateProjectResponseType.NameExists };
                        return;
                    }

                    var project = new Project();
                    project.Set(request);
                    dbContext.Projects.Add(project);
                    dbContext.SaveChanges();

                    Response = new CreateProjectResponse
                    {
                        Identifier = project.Identifier,
                        Type = CreateProjectResponseType.Success,
                    };
                }
            }
        }
    }
}


