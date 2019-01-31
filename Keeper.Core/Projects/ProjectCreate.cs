using Keeper.CoreContract.Projects;
using Keeper.Data;
using Keeper.Data.Projects;
using System;
using System.Linq;

namespace Keeper.Core.Projects
{
    public class ProjectCreate
    {
        public ProjectCreateResponse Response { get; private set; }

        public ProjectCreate(ProjectCreateRequest request)
        {
            if (request != null)
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    Response = new ProjectCreateResponse
                    { Type = ProjectCreateResponseType.NameEmpty };
                    return;
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    if (dbContext.Projects.Any(aProject => aProject.Name.ToLower().Trim() == request.Name.ToLower().Trim()))
                    {
                        Response = new ProjectCreateResponse
                        { Type = ProjectCreateResponseType.NameExists };
                        return;
                    }

                    var projectNameWords = request.Name.Split(' ');
                    var projectKey = projectNameWords.Count() > 0 
                        ? string.Join("", projectNameWords.Select(aWord => aWord[0])) 
                        : projectNameWords.Take(3).ToString();

                    if (dbContext.Projects.Any(aProject => aProject.Key == projectKey.ToUpper().Trim()))
                        throw new NotImplementedException();

                    var project = new Project();
                    project.Set(request,projectKey);
                    dbContext.Projects.Add(project);
                    dbContext.SaveChanges();

                    Response = new ProjectCreateResponse
                    {
                        Identifier = project.Identifier,
                        Type = ProjectCreateResponseType.Success,
                    };
                }
            }
        }
    }
}


