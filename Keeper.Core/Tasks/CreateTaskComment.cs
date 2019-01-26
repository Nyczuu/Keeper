using Keeper.CoreContract.Tasks;
using Keeper.Data;
using Keeper.Data.Tasks;

namespace Keeper.Core.Tasks
{
    public class CreateTaskComment
    {
        public CreateTaskCommentResponse Response { get; private set; }

        public CreateTaskComment(CreateTaskCommentRequest request)
        {
            if (request != null)
            {
                if (string.IsNullOrWhiteSpace(request.Content))
                {
                    Response = new CreateTaskCommentResponse
                    { Type = CreateTaskCommentResponseType.ContentEmpty };
                    return;
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    var taskComment = new TaskComment();
                    taskComment.Set(request);
                    dbContext.TaskComents.Add(taskComment);
                    dbContext.SaveChanges();

                    Response = new CreateTaskCommentResponse
                    { Type = CreateTaskCommentResponseType.Success };
                }
            }
        }
    }
}
