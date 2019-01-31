using Keeper.Core.Helpers;
using Keeper.CoreContract.Users;
using Keeper.Data;
using Keeper.Data.Users;
using System.Linq;

namespace Keeper.Core.Users
{
    public class UserCreate
    {
        public UserCreateResponse Response { get; private set; }

        public UserCreate(UserCreateRequest request)
        {
            if (request != null)
            {
                if (string.IsNullOrWhiteSpace(request.Email) || !EmailHelper.IsValidEmail(request.Email))
                {
                    Response = new UserCreateResponse
                    { Type = UserCreateResponseType.EmailNotValid };
                    return;
                }

                //TODO: Password regex check (force min 10 characters etc)
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    Response = new UserCreateResponse
                    { Type = UserCreateResponseType.PasswordTooWeak };
                    return;
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    if (dbContext.Users.Any(aUser => aUser.Email.ToLower().Trim() == request.Email.ToLower().Trim()))
                    {
                        Response = new UserCreateResponse
                        { Type = UserCreateResponseType.EmailExists };
                        return;
                    }
                    var user = new User();
                    user.Set(request);
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();

                    Response = new UserCreateResponse
                    {
                        Identifier = user.Identifier,
                        Type = UserCreateResponseType.Success,
                    };
                }
            }
        }
    }
}
