using Keeper.Core.Helpers;
using Keeper.CoreContract.Users;
using Keeper.Data;
using Keeper.Data.Users;
using System;
using System.Linq;

namespace Keeper.Core.Users
{
    public class UserLogin
    {
        public UserLoginResponse Response { get; private set; }

        public UserLogin(UserLoginRequest request)
        {
            if (request != null)
            {
                if (string.IsNullOrWhiteSpace(request.Email) || !EmailHelper.IsValidEmail(request.Email))
                {
                    Response = new UserLoginResponse
                    { Type = UserLoginResponseType.WrongEmail };
                    return;
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    var user = dbContext.Users.SingleOrDefault(aUser => aUser.Email.Trim().ToLower() == request.Email.Trim().ToLower());

                    if (user == null)
                    {
                        Response = new UserLoginResponse
                        { Type = UserLoginResponseType.NoUser };
                        return;
                    }

                    if (user.Password != request.Password)
                    {
                        Response = new UserLoginResponse
                        { Type = UserLoginResponseType.WrongPassword };
                        return;
                    }

                    var sessionKey = Guid.NewGuid();
                    var userSession = new UserSession();
                    userSession.Set(request, sessionKey, user.Identifier);
                    dbContext.UserSessions.Add(userSession);
                    dbContext.SaveChanges();

                    Response = new UserLoginResponse
                    {
                        Type = UserLoginResponseType.Success,
                        SessionKey = sessionKey,
                    };
                }
            }
        }
    }
}
