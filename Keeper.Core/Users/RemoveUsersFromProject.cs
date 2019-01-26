using Keeper.CoreContract.Users;
using Keeper.Data;
using System.Linq;

namespace Keeper.Core.Users
{
    public class RemoveUsersFromProject
    {
        public RemoveUsersFromProjectResponse Response;

        public RemoveUsersFromProject(RemoveUsersFromProjectRequest request)
        {
            if(request != null && request.UsersIdentifiers != null && request.UsersIdentifiers.Any())
            {
                using(var dbContext = new ApplicationDbContext())
                {
                    var project = dbContext.Projects.SingleOrDefault(aProject => aProject.Identifier == request.ProjectIdentifier);

                    if (project != null)
                    {
                        var users = project.Users.Where(aUser => request.UsersIdentifiers.Contains(aUser.Identifier));

                        foreach (var user in users)
                            project.Users.Remove(user);

                        dbContext.SaveChanges();
                        Response = new RemoveUsersFromProjectResponse();
                    }
                }
            }
        }
    }
}