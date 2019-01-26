using Keeper.Core.Helpers;
using Keeper.CoreContract.Users;
using Keeper.Data;
using Keeper.Data.Users;
using System.Linq;

namespace Keeper.Core.Users
{
    public class CreateUser
    {
        public CreateUserResponse Response { get; private set; }

        public CreateUser(CreateUserRequest request)
        {
            if (request != null)
            {
                if (string.IsNullOrWhiteSpace(request.Email) || !EmailHelper.IsValidEmail(request.Email))
                {
                    Response = new CreateUserResponse
                    { Type = CreateUserResponseType.EmailNotValid };
                    return;
                }

                //TODO: Password regex check (force min 10 characters etc)
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    Response = new CreateUserResponse
                    { Type = CreateUserResponseType.PasswordTooWeak };
                    return;
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    if (dbContext.Users.Any(aUser => aUser.Email.ToLower().Trim() == request.Email.ToLower().Trim()))
                    {
                        Response = new CreateUserResponse
                        { Type = CreateUserResponseType.EmailExists };
                        return;
                    }
                    var user = new User();
                    user.Set(request);
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();

                    Response = new CreateUserResponse
                    {
                        Identifier = user.Identifier,
                        Type = CreateUserResponseType.Success,
                    };
                }
            }
        }
    }
}
