using System.Linq;

namespace Keeper.CoreContract.Tasks

{
    public class GetTaskResponseItem
    {
        public int Identifier;
        public string Name;
        public string Description;
        public int ProjectIdentifier;

        public override string ToString()
        {
            //var desc = Description.Take(50).ToString();
            return $"{Name}: {Description}";
        }
    }
}
