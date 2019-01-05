using Keeper.CoreContract.Users;
using Keeper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* */ 

namespace Keeper.Core.Users
{
    public class LoginUser
    {
        public LoginUserResponse Response{get; private set;}
        
        public LoginUser(LoginUserRequest request)
        {
            if (request != null)
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var user = dbContext.Users.SingleOrDefault(aUser
                        => aUser.Email == request.Email);

                    if (user != null)
                    {
                        if (user.Password == request.Password)
                        {
                            Response = new LoginUserResponse { Status = LoginUserResponseStatus.Success };
                        }
                        else
                        {
                            Response = new LoginUserResponse { Status = LoginUserResponseStatus.WrongPassword };
                        }
                    }
                    else
                    {
                        Response = new LoginUserResponse { Status = LoginUserResponseStatus.EmailNotFound };
                    }
                }
            }
        }
    }
}
