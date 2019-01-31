using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.CoreContract.Tasks
{
    public class TaskGet1Request
    {
        public int[] TaskIdentifiers;
        public int[] ProjectIdentifiers;
        public string SearchKeyword;
        public TaskStatus? Status;
    }
}
