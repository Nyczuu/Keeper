using Keeper.CoreContract.Tasks;
using Keeper.Data;
using System.Linq;

namespace Keeper.Core.Tasks
{
    public class DeleteTask
    {
        public DeleteTaskResponse Response { get; private set; }

        public DeleteTask(DeleteTaskRequest request)
        {
            if (request != null && request.Identifiers != null && request.Identifiers.Any())
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var tasksToDelete = dbContext.Tasks.Where(aTask
                        => request.Identifiers.Contains(aTask.Identifier));

                    dbContext.Tasks.RemoveRange(tasksToDelete);
                    dbContext.SaveChanges();
                }

                Response = new DeleteTaskResponse();
            }
        }
    }
}
