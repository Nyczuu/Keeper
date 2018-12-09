using Keeper.Core.Users;
using Keeper.CoreContract.Users;

namespace Keeper.Core
{
    public class Client
    {
        public CreateUserResponse CreateUser(CreateUserRequest request)
            => new CreateUser(request).Response;
    }
}
