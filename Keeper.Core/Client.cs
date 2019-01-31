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

        public UserCreateResponse UserCreate(UserCreateRequest request)
            => new UserCreate(request).Response;

        public UserGet1Response UserGet1(UserGet1Request request)
            => new UserGet1(request).Response;

        public UserDeleteResponse UserDelete(UserDeleteRequest request)
            => new UserDelete(request).Response;

        public UserLoginResponse UserLogin(UserLoginRequest request)
            => new UserLogin(request).Response;

        public UserSessionGetResponse UserSessionGet(UserSessionGetRequest request)
            => new UserSessionGet(request).Response;

        public UserAddToProjectResponse UserAddToProject(UserAddToProjectRequest request)
            => new UserAddToProject(request).Response;

        public UserRemoveFromProjectResponse UserRemoveFromProject(UserRemoveFromProjectRequest request)
            => new UserRemoveFromProject(request).Response;

        #endregion
        
        #region Projects

        public ProjectCreateResponse ProjectCreate(ProjectCreateRequest request)
            => new ProjectCreate(request).Response;

        public ProjectGet1Response ProjectGet1(ProjectGet1Request request)
            => new ProjectGet1(request).Response;

        public ProjectDeleteResponse ProjectDelete(ProjectDeleteRequest request)
            => new ProjectDelete(request).Response;

        #endregion

        #region Tasks

        public TaskCreateResponse TaskCreate(TaskCreateRequest request)
            => new TaskCreate(request).Response;

        public TaskGet1Response TaskGet1(TaskGet1Request request)
            => new TaskGet1(request).Response;

        public TaskDeleteResponse TaskDelete(TaskDeleteRequest request)
            => new TaskDelete(request).Response;

        public TaskUpdateResponse TaskUpdate(TaskUpdateRequest request)
            => new TaskUpdate(request).Response;

        public TaskStartResponse TaskStart(TaskStartRequest request)
            => new TaskStart(request).Response;

        public TaskCommentCreateResponse TaskCommentCreate(TaskCommentCreateRequest request)
            => new TaskCommentCreate(request).Response;

        public TaskWorklogCreateResponse TaskWorklogCreate(TaskWorklogCreateRequest request)
            => new TaskWorklogCreate(request).Response;

        #endregion
    }
}
