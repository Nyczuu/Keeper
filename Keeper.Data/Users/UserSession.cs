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
        public int UserIdentifier { get; private set; }

        public Guid SessionKey { get; private set; }

        public DateTime? FinishedOnUtc { get; private set; }

        public virtual User User { get; private set; }

        public void Set(LoginUserRequest request, Guid sessionKey, int userIdentifier)
        {
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;

            SessionKey = sessionKey;
            UserIdentifier = userIdentifier;
        }
    }
}
