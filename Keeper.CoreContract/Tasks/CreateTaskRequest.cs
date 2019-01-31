namespace Keeper.CoreContract.Tasks
{
    public class CreateTaskRequest
    {
        public string Name;
        public string Description;
        public int ProjectIdentifier;
        public int? AssigneeIdentifier;
        public int CreatorIdentifier;
    }
}
