﻿using Keeper.CoreContract.Users;
using Keeper.Data;
using System.Linq;

namespace Keeper.Core.Users
{
    public class UserAddToProject
    {
        public UserAddToProjectResponse Response { get; private set; }

        public UserAddToProject(UserAddToProjectRequest request)
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
                        Response = new UserAddToProjectResponse();
                    }
                }
            }
        }
    }
}
