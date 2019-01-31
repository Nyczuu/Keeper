using Keeper.CoreContract.Tasks;
using Keeper.Data;
using Keeper.Data.Tasks;

namespace Keeper.Core.Tasks
{
    public class TaskCommentCreate
    {
        public TaskCommentCreateResponse Response { get; private set; }

        public TaskCommentCreate(TaskCommentCreateRequest request)
        {
            if (request != null)
            {
                if (string.IsNullOrWhiteSpace(request.Content))
                {
                    Response = new TaskCommentCreateResponse
                    { Type = TaskCommentCreateResponseType.ContentEmpty };
                    return;
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    var taskComment = new TaskComment();
                    taskComment.Set(request);
                    dbContext.TaskComents.Add(taskComment);
                    dbContext.SaveChanges();

                    Response = new TaskCommentCreateResponse
                    { Type = TaskCommentCreateResponseType.Success };
                }
            }
        }
    }
}
