using Keeper.Core;
using Keeper.CoreContract.Users;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Keeper.WPF.ProjectManager
{
    public partial class ProjectManageWindow : Window
    {
        private int _projectIdentifier;

        public ProjectManageWindow(int projectIdentifier)
        {
            _projectIdentifier = projectIdentifier;

            InitializeComponent();
            WorkersList.SelectionMode = SelectionMode.Multiple;
            WorkersAssignedList.SelectionMode = SelectionMode.Multiple;

            ReloadWorkersLists();
        }

        private void WorkersAssignButton_Click(object sender, RoutedEventArgs e)
        {
            if (WorkersList.SelectedItems.Count > 0)
            {
                new Client().AddUsersToProject(new AddUsersToProjectRequest
                {
                    ProjectIdentifier = _projectIdentifier,
                    UsersIdentifiers = WorkersList.SelectedItems.Cast<GetUserResponseItem>()
                    .Select(aUser => aUser.Identifier).ToArray()
                });
            }
            ReloadWorkersLists();
        }

        private void WorkersUnassignButton_Click(object sender, RoutedEventArgs e)
        {
            if (WorkersAssignedList.SelectedItems.Count > 0)
            {
                new Client().RemoveUsersFromProject(new RemoveUsersFromProjectRequest
                {
                    ProjectIdentifier = _projectIdentifier,
                    UsersIdentifiers = WorkersAssignedList.SelectedItems.Cast<GetUserResponseItem>()
                    .Select(aUser => aUser.Identifier).ToArray(),
                });
            }
            ReloadWorkersLists();
        }

        private void ReloadWorkersLists()
        {
            var users = new Client().GetUser(new GetUserRequest
            { UserGroup = UserGroupType.Worker }).Items;

            var assignedUsers = new Client().GetUser(new GetUserRequest
            { UserGroup = UserGroupType.Worker, ProjectsIdentifiers = new int[] { _projectIdentifier } }).Items;

            WorkersList.ItemsSource = users.Except(assignedUsers);
            WorkersAssignedList.ItemsSource = assignedUsers;
        }
    }
}
