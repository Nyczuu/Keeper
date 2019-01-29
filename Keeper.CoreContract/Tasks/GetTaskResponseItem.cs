using System.Linq;

namespace Keeper.CoreContract.Tasks

{
    public class GetTaskResponseItem
    {
        public int Identifier;
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
