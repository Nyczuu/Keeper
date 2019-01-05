using Keeper.CoreContract;
using Keeper.CoreContract.Users;
using Keeper.Data;
using Keeper.Data.Migrations;
using Keeper.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Core.Users
{
    public class LoginUser
    {
        public LoginUserResponse Response { get; private set; }

        public LoginUser(LoginUserRequest request)
        {
            Response = new LoginUserResponse();
            if (request != null)
            {
                if (string.IsNullOrWhiteSpace(request.Email)) // todo: regex 
                    Response.Type = LoginUserResponseType.WrongEmail;
                else if (string.IsNullOrWhiteSpace(request.Password))
                    Response.Type = LoginUserResponseType.WrongPassword;
                else
                    using (var dbContext = new ApplicationDbContext())
                    {
                        var user = dbContext.Users.SingleOrDefault(aUser
                            => aUser.Email.ToLower()
                            == request.Email.ToLower());
                        if (user == null)
                            Response.Type = LoginUserResponseType.NoUser;
                        else
                            if (user.Password != request.Password)
                            Response.Type = LoginUserResponseType.WrongPassword;
                        else
                        {
                            var userSessionId = Guid.NewGuid();
                            var userSession = new UserSession();
                            userSession.Set(request, userSessionId, user.Identifier);
                            dbContext.SaveChanges(); 

                            Response.Type = LoginUserResponseType.Success;
                            Response.SessionId = userSessionId;
                        }
                    }
            }
        }
    }
}
