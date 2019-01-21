using Keeper.CoreContract.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Data.Users
{
    public class UserSession : BaseEntity
    {
        public int UserId { get; private set; }

        public Guid SessionId { get; private set; }

        public DateTime FinishedOnUtc { get; private set; }

        public virtual User User { get; private set; }

        public void Set(LoginUserRequest request, Guid sessionId, int userId)
        {
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;
            SessionId = sessionId;
            UserId = userId;
        }
    }
}
