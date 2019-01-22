using System;
using Keeper.Core.Projects;
using Keeper.Core.Tasks;
using Keeper.Core.Users;
using Keeper.CoreContract.Projects;
using Keeper.CoreContract.Tasks;
using Keeper.CoreContract.Users;

namespace Keeper.Core
{
    public class Client
    {
        #region Users

        public CreateUserResponse CreateUser(CreateUserRequest request)
            => new CreateUser(request).Response;

        public GetUserResponse GetUser(GetUserRequest request)
            => new GetUser(request).Response;

        public DeleteUserResponse DeleteUser(DeleteUserRequest request)
            => new DeleteUser(request).Response;

        public LoginUserResponse LoginUser(LoginUserRequest request)
            => new LoginUser(request).Response;

        public GetUserSessionResponse GetUserSession(GetUserSessionRequest request)
            => new GetUserSession(request).Response;

        public AddUsersToProjectResponse AddUsersToProject(AddUsersToProjectRequest request)
            => new AddUsersToProject(request).Response;

        #endregion
        
        #region Projects

        public CreateProjectResponse CreateProject(CreateProjectRequest request)
            => new CreateProject(request).Response;

        public DeleteProjectResponse DeleteProject(DeleteProjectRequest request)
            => new DeleteProject(request).Response;

        #endregion

        #region Tasks

        public CreateTaskResponse CreateTask(CreateTaskRequest request)
            => new CreateTask(request).Response;


        #endregion
    }
}
