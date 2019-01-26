using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.CoreContract.Projects
{
    public class GetProjectResponseItem
    {
        public int Identifier;
        public string Name;
        public int TasksCount;

        public override string  ToString()
        {
            return $"{Name} ({TasksCount})";
        }
    }
}
