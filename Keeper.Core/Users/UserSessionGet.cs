using Keeper.CoreContract.Users;
using Keeper.Data;
using System.Linq;

namespace Keeper.Core.Users
{
    class UserSessionGet
    {
        public UserSessionGetResponse Response { get; private set; }

        public UserSessionGet(UserSessionGetRequest request)
        {
            if(request != null && request.SessionKey != null)
            {
                using(var dbContext = new ApplicationDbContext())
                {
                    var session = dbContext.UserSessions.SingleOrDefault(aUserSession => aUserSession.SessionKey == request.SessionKey);

                    if (session != null && session.User != null)
                    {
                        Response = new UserSessionGetResponse
                        {
                            SessionKey = session.SessionKey,
                            UserIdentifier = session.User.Identifier,
                            UserEmail = session.User.Email,
                            UserGroupType = session.User.GroupType,
                        };
                    }
                }
            }
        }
    }
}
