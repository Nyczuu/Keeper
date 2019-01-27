using Keeper.CoreContract.Users;
using Keeper.Data;
using System.Linq;

namespace Keeper.Core.Users
{
    public class AddUsersToProject
    {
        public AddUsersToProjectResponse Response { get; private set; }

        public AddUsersToProject(AddUsersToProjectRequest request)
        {
            if (request != null && request.UsersIdentifiers != null && request.UsersIdentifiers.Any())
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var project = dbContext.Projects.SingleOrDefault(aProject => aProject.Identifier == request.ProjectIdentifier);

                    if (project != null)
                    {
                        var users = dbContext.Users.Where(aUser => request.UsersIdentifiers.Contains(aUser.Identifier)).ToArray();

                        foreach (var user in users)
                            user.Projects.Add(project);

                        dbContext.SaveChanges();
                        Response = new AddUsersToProjectResponse();
                    }
                }
            }
        }
    }
}
