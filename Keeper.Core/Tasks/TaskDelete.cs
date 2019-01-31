using Keeper.CoreContract.Tasks;
using Keeper.Data;
using System.Linq;

namespace Keeper.Core.Tasks
{
    public class TaskDelete
    {
        public TaskDeleteResponse Response { get; private set; }

        public TaskDelete(TaskDeleteRequest request)
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

                Response = new TaskDeleteResponse();
            }
        }
    }
}
