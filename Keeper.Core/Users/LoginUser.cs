using Keeper.Core.Helpers;
using Keeper.CoreContract.Users;
using Keeper.Data;
using Keeper.Data.Users;
using System;
using System.Linq;

namespace Keeper.Core.Users
{
    public class LoginUser
    {
        public LoginUserResponse Response { get; private set; }

        public LoginUser(LoginUserRequest request)
        {
            if (request != null)
            {
                if (string.IsNullOrWhiteSpace(request.Email) || !EmailHelper.IsValidEmail(request.Email))
                {
                    Response = new LoginUserResponse
                    { Type = LoginUserResponseType.WrongEmail };
                    return;
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    var user = dbContext.Users.SingleOrDefault(aUser => aUser.Email.Trim().ToLower() == request.Email.Trim().ToLower());

                    if (user == null)
                    {
                        Response = new LoginUserResponse
                        { Type = LoginUserResponseType.NoUser };
                        return;
                    }

                    if (user.Password != request.Password)
                    {
                        Response = new LoginUserResponse
                        { Type = LoginUserResponseType.WrongPassword };
                        return;
                    }

                    var sessionKey = Guid.NewGuid();
                    var userSession = new UserSession();
                    userSession.Set(request, sessionKey, user.Identifier);
                    dbContext.UserSessions.Add(userSession);
                    dbContext.SaveChanges();

                    Response = new LoginUserResponse
                    {
                        Type = LoginUserResponseType.Success,
                        SessionKey = sessionKey,
                    };
                }
            }
        }
    }
}
