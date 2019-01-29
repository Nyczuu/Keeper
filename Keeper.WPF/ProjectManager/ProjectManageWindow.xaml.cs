using Keeper.Core;
using Keeper.CoreContract.Tasks;
using Keeper.CoreContract.Users;
using Keeper.WPF.Extensions;
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
            InitializeUsersTab();
            InitializeTasksTab();
        }

        #region Users

        private void InitializeUsersTab()
        {
            WorkersList.SetDefaults();
            WorkersAssignedList.SetDefaults();
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

            WorkersAssignedList.ItemsSource = assignedUsers;
            WorkersList.ItemsSource = users.Where(aUser => !assignedUsers.Select(anAssignedUser
                => anAssignedUser.Identifier).Contains(aUser.Identifier));
        }

        #endregion

        #region Tasks

        private void InitializeTasksTab()
        {
            TaskList.SetDefaults();
            TaskSearchStatusComboBox.Items.Add(new TaskSearchStatusComboBoxItemModel(0, "All"));
            foreach (TaskStatus status in Enum.GetValues(typeof(TaskStatus)))
                TaskSearchStatusComboBox.Items.Add(new TaskSearchStatusComboBoxItemModel(status));

            ReloadTaskList();
        }

        private void TaskAddButton_Click(object sender, RoutedEventArgs e)
        {
            var taskAddWindow = new AddTaskWindow(_projectIdentifier);
            App.Current.MainWindow = taskAddWindow;
            taskAddWindow.ShowDialog();
            ReloadTaskList();
        }

        private void TaskEditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TaskDeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TaskSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadTaskList();
        }

        private void TaskSearchStatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReloadTaskList();
        }

        private void TaskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TaskList.SelectedItems.Count == 1)
            {
                TaskAddButton.Visibility = Visibility.Hidden;
                TaskEditButton.Visibility = Visibility.Visible;
                TaskDeleteButton.Visibility = Visibility.Visible;
            }
            else if (TaskList.SelectedItems.Count > 1)
            {
                TaskAddButton.Visibility = Visibility.Hidden;
                TaskEditButton.Visibility = Visibility.Hidden;
                TaskDeleteButton.Visibility = Visibility.Visible;
            }
            else
            {
                TaskAddButton.Visibility = Visibility.Visible;
                TaskEditButton.Visibility = Visibility.Hidden;
                TaskDeleteButton.Visibility = Visibility.Hidden;
            }
        }

        private void ReloadTaskList()
        {
            var selectedStatus = ((TaskSearchStatusComboBoxItemModel)TaskSearchStatusComboBox.SelectedItem)?.Identifier;

            var tasks = new Client().GetTask(new GetTaskRequest
            {
                ProjectIdentifiers = new int[] { _projectIdentifier },
                SearchKeyword = TaskSearchTextBox.Text,
                Status = selectedStatus != 0 ? (TaskStatus?)selectedStatus : null,
            }).Items;

            TaskList.ItemsSource = tasks.Select(aTask 
                => new TaskListItemModel
                {
                    Identifier = aTask.Identifier,
                    Name = aTask.Name,
                    Status = aTask.Status,
                }).ToList();
        }

        #endregion
    }
}
