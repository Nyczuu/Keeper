using Keeper.CoreContract.Users;
using System;
namespace Keeper.WPF
{
    public class WorkContext
    {
        public Guid SessionKey { get; private set; }
        public CurrentlyLoggedOnUser CurrentlyLoggedOnUser { get; private set; }

        private static WorkContext instance = null;
        private static readonly object padlock = new object();

        WorkContext() { }

        public static WorkContext Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new WorkContext();
                    }
                    return instance;
                }
            }
        }

        public void Initialize(UserSessionGetResponse response)
        {
            SessionKey = response.SessionKey;
            CurrentlyLoggedOnUser = new CurrentlyLoggedOnUser(response);
        }
    }
}
