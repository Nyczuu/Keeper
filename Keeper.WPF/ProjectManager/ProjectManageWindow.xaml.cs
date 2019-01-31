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

        #region Details

        #endregion

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
                new Client().UserAddToProject(new UserAddToProjectRequest
                {
                    ProjectIdentifier = _projectIdentifier,
                    UsersIdentifiers = WorkersList.SelectedItems.Cast<UserGet1ResponseItem>()
                    .Select(aUser => aUser.Identifier).ToArray()
                });
            }
            ReloadWorkersLists();
        }

        private void WorkersUnassignButton_Click(object sender, RoutedEventArgs e)
        {
            if (WorkersAssignedList.SelectedItems.Count > 0)
            {
                new Client().UserRemoveFromProject(new UserRemoveFromProjectRequest
                {
                    ProjectIdentifier = _projectIdentifier,
                    UsersIdentifiers = WorkersAssignedList.SelectedItems.Cast<UserGet1ResponseItem>()
                    .Select(aUser => aUser.Identifier).ToArray(),
                });
            }
            ReloadWorkersLists();
        }

        private void ReloadWorkersLists()
        {
            var users = new Client().UserGet1(new UserGet1Request
            { UserGroup = UserGroupType.Worker }).Items;

            var assignedUsers = new Client().UserGet1(new UserGet1Request
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
            TaskSearchStatusComboBox.Items.Add(new TaskSearchStatusComboBoxItemModel { Identifier = 0, Value = "All" });
            foreach (TaskStatus status in Enum.GetValues(typeof(TaskStatus)))
            {
                TaskSearchStatusComboBox.Items.Add(
                    new TaskSearchStatusComboBoxItemModel
                    {
                        Identifier = (int)status,
                        Value = status.ToString()
                    });
            }

            ReloadTaskList();
        }

        private void TaskCreateButton_Click(object sender, RoutedEventArgs e)
        {
            var taskCreateWindow = new TaskCreateWindow(_projectIdentifier);
            App.Current.MainWindow = taskCreateWindow;
            taskCreateWindow.ShowDialog();
            ReloadTaskList();
        }

        private void TaskEditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TaskDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItems.Count > 0)
            {
                new Client().TaskDelete(new TaskDeleteRequest
                {
                    Identifiers = TaskList.SelectedItems
                    .Cast<TaskListItemModel>()
                    .Select(aSelectedItem => aSelectedItem.Identifier)
                    .ToArray()
                });
            }

            ReloadTaskList();
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
                TaskCreateButton.Visibility = Visibility.Hidden;
                TaskEditButton.Visibility = Visibility.Visible;
                TaskDeleteButton.Visibility = Visibility.Visible;
            }
            else if (TaskList.SelectedItems.Count > 1)
            {
                TaskCreateButton.Visibility = Visibility.Hidden;
                TaskEditButton.Visibility = Visibility.Hidden;
                TaskDeleteButton.Visibility = Visibility.Visible;
            }
            else
            {
                TaskCreateButton.Visibility = Visibility.Visible;
                TaskEditButton.Visibility = Visibility.Hidden;
                TaskDeleteButton.Visibility = Visibility.Hidden;
            }
        }

        private void ReloadTaskList()
        {
            var selectedStatus = ((TaskSearchStatusComboBoxItemModel)TaskSearchStatusComboBox.SelectedItem)?.Identifier;

            var tasks = new Client().TaskGet1(new TaskGet1Request
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
                    Number = aTask.Number,
                    Status = aTask.Status,
                }).ToList();
        }

        #endregion
    }
}
