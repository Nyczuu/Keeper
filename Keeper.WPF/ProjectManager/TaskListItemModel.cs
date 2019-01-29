using Keeper.CoreContract.Tasks;

namespace Keeper.WPF.ProjectManager
{
    class TaskListItemModel
    {
        public int Identifier { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
    }
}
