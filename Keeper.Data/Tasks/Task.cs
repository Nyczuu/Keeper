using Keeper.Data.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Data.Tasks
{
    public class Task : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ProjectIdentifier { get; private set; }
        public TaskStatus Status { get; private set; }

        public virtual Project Project { get; set; }
    }
}
