using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.CoreContract.Tasks
{
    public enum TaskStatus
    {
        Open = 1,
        InProgress,
        Finished,
        Reopened,
        Closed,
    }
}
