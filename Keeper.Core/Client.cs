using Keeper.Core.Users;
using Keeper.CoreContract.Users;

namespace Keeper.Core
{
    public class Client
    {
        public CreateUserResponse CreateUser(CreateUserRequest request)
            => new CreateUser(request).Response;

        public GetUserResponse GetUser(GetUserRequest request)
            => new GetUser(request).Response;

        public DeleteUserResponse DeleteUser(DeleteUserRequest request)
            => new DeleteUser(request).Response;

        public LoginUserResponse LoginUser(LoginUserRequest request)
            => new LoginUser(request).Response;

    }
}
