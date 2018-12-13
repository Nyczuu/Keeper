using Keeper.CoreContract.Users;
using Keeper.Data;
using System.Linq;

namespace Keeper.Core.Users
{
    public class GetUser
    {
        public GetUserResponse Response { get; private set; }

        public GetUser(GetUserRequest request)
        {
            if(request != null)
            {
                using(var dbContext = new ApplicationDbContext())
                {
                    var query = dbContext.Users.AsQueryable();

                    if (request.UsersIdentifiers != null && request.UsersIdentifiers.Any())
                        query = query.Where(aUser => request.UsersIdentifiers.Contains(aUser.Identifier));

                    Response = new GetUserResponse
                    {
                        Items = query.Select(aUser => new GetUserResponseItem
                        {
                            Identifier = aUser.Identifier,
                            Email = aUser.Email,
                        }).ToArray(),
                    };
                }
            }
        }
    }
}
