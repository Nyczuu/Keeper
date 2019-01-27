using Keeper.Core;
using Keeper.CoreContract.Tasks;
using Keeper.CoreContract.Users;
using System;
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

            TaskSearchStatusComboBox.Items.Add(new TaskSearchStatusComboBoxItemModel(0, "All"));
            foreach (var status in Enum.GetValues(typeof(TaskStatus)))
                TaskSearchStatusComboBox.Items.Add(status);

            ReloadWorkersLists();
            ReloadTaskList();
        }

        #region Users

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

            WorkersAssignedList.ItemsSource = assignedUsers;
            WorkersList.ItemsSource = users.Where(aUser => !assignedUsers.Select(anAssignedUser
                => anAssignedUser.Identifier).Contains(aUser.Identifier));
        }

        #endregion

        #region Tasks

        private void TaskAddButton_Click(object sender, RoutedEventArgs e)
        {
            var taskAddWindow = new AddTaskWindow(_projectIdentifier);
            App.Current.MainWindow = taskAddWindow;
            taskAddWindow.ShowDialog();
        }

        private void TaskSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadTaskList();
        }

        private void ReloadTaskList()
        {
            var selectedStatus = ((TaskSearchStatusComboBoxItemModel)TaskSearchStatusComboBox.SelectedItem)?.Identifier;

            TaskList.ItemsSource = new Client().GetTask(new GetTaskRequest
            {
                ProjectIdentifiers = new int[] { _projectIdentifier },
                SearchKeyword = TaskSearchTextBox.Text,
                Status = selectedStatus != 0 ? (TaskStatus?)TaskSearchStatusComboBox.SelectedItem : null,
            }).Items;
        }

        #endregion
    }
}
