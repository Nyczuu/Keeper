using Keeper.CoreContract.Users;
using Keeper.Data;
using Keeper.Data.Users;

namespace Keeper.Core.Users
{
    public class CreateUser
    {
        public CreateUserResponse Response { get; private set; }

        public CreateUser(CreateUserRequest request)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                //TODO: VALIDATION

                var user = new User();
                user.Set(request);

                dbContext.Users.Add(user);
                dbContext.SaveChanges();

                Response = new CreateUserResponse
                {
                    Identifier = user.Identifier,
                    Success = true
                };
            }
        }
    }
}
