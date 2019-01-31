namespace Keeper.CoreContract.Tasks
{
    public class TaskCreateRequest
    {
        public string Name;
        public string Description;
        public int ProjectIdentifier;
        public int? AssigneeIdentifier;
        public int CreatorIdentifier;
    }
}
