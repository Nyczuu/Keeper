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
                    {
                        Type = CreateProjectResponseType.EmptyName
                    };
                }
                else
                {
                    using (var dbContext = new ApplicationDbContext())
                    {
                        var projects = dbContext.Set<Project>().AsQueryable();

                        if (projects.SingleOrDefault(aProject
                             => aProject.Name.ToLower() == request.Name.ToLower()) != null)
                        {
                            Response = new CreateProjectResponse
                            {
                                Type = CreateProjectResponseType.NameExists
                            };
                        }
                        else
                        {
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
    }
}


