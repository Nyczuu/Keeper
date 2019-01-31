using System.Linq;

namespace Keeper.CoreContract.Tasks

{
    public class TaskGet1ResponseItem
    {
        public int Identifier;
        public string Number;
        public string Name;
        public string Description;
        public int ProjectIdentifier;
        public TaskStatus Status;

        public override string ToString()
        {
            return $"{Name}: {Description}";
        }
    }
}
