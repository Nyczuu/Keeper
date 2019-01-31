using Keeper.CoreContract.Users;
using Keeper.Data;
using System.Linq;

namespace Keeper.Core.Users
{
    public class UserGet1
    {
        public UserGet1Response Response { get; private set; }

        public UserGet1(UserGet1Request request)
        {
            if(request != null)
            {
                using(var dbContext = new ApplicationDbContext())
                {
                    var query = dbContext.Users.AsQueryable();

                    if (request.UsersIdentifiers != null && request.UsersIdentifiers.Any())
                        query = query.Where(aUser => request.UsersIdentifiers.Contains(aUser.Identifier));

                    if (request.ProjectsIdentifiers != null && request.ProjectsIdentifiers.Any())
                        query = query.Where(aUser => aUser.Projects.Any(aProject 
                            => request.ProjectsIdentifiers.Contains(aProject.Identifier)));

                    if (!string.IsNullOrWhiteSpace(request.SearchKeyword))
                        query = query.Where(aUser => aUser.Email.ToLower().Contains(request.SearchKeyword.ToLower()));

                    if (request.UserGroup != null)
                        query = query.Where(aUser => aUser.GroupType == request.UserGroup);

                    Response = new UserGet1Response
                    {
                        Items = query.Select(aUser => new UserGet1ResponseItem
                        {
                            Identifier = aUser.Identifier,
                            Email = aUser.Email,
                            Group = aUser.GroupType,
                        }).ToArray(),
                    };
                }
            }
        }
    }
}
