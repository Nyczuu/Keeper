namespace Keeper.CoreContract.Projects
{
    public class ProjectGet1ResponseItem
    {
        public int Identifier;
        public string Name;
        public string Key;
        public int TasksCount;

        public override string  ToString()
        {
            return $"{Name} [{Key}] ({TasksCount})";
        }
    }
}
