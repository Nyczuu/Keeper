using Keeper.CoreContract.Tasks;
using Keeper.Data;
using Keeper.Data.Tasks;
using System.Linq;

namespace Keeper.Core.Tasks
{
    public class CreateTaskWorklog
    {
        public CreateTaskWorklogResponse Response { get; private set; }

        public CreateTaskWorklog(CreateTaskWorklogRequest request)
        {
            if (request != null)
            {
                if (request.StartDate > request.FinishDate)
                    Response = new CreateTaskWorklogResponse
                    { Type = CreateTaskWorklogResponseType.StartAndFinishPeriodNotValid };

                else if ((request.FinishDate - request.StartDate).TotalMinutes < 1)
                    Response = new CreateTaskWorklogResponse
                    { Type = CreateTaskWorklogResponseType.StartAndFinishPeriodLessThanOneMinute };

                else
                {
                    using(var dbContext = new ApplicationDbContext())
                    {
                        var task = dbContext.Tasks.SingleOrDefault(aTask
                            => aTask.Identifier == request.TaskIdentifier);

                        if (task == null)
                            Response = new CreateTaskWorklogResponse
                            { Type = CreateTaskWorklogResponseType.TaskDoesNotExist };

                        else
                        {
                            var user = dbContext.Users.SingleOrDefault(aUser
                                => aUser.Identifier == request.UserIdentifier);

                            if(user == null)
                                Response = new CreateTaskWorklogResponse
                                { Type = CreateTaskWorklogResponseType.UserDoesNotExist };

                            else
                            {
                                var worklog = new TaskWorklog();
                                worklog.Set(request);
                                dbContext.TaskWorklogs.Add(worklog);
                                dbContext.SaveChanges();

                                Response = new CreateTaskWorklogResponse
                                { Type = CreateTaskWorklogResponseType.Success };
                            }
                        }
                    }
                }
            }
        }
    }
}
