using Keeper.Core;
using Keeper.CoreContract.Projects;
using Keeper.CoreContract.Tasks;
using Keeper.CoreContract.Users;
using Keeper.WPF.Admin;
using Keeper.WPF.ProjectManager;
using System.Windows;
using System.Windows.Controls;

namespace Keeper.WPF
{
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();

            if (WorkContext.Instance.CurrentlyLoggedOnUser.GroupType == UserGroupType.Administrator)
                UserManageButton.Visibility = Visibility.Visible;

            if (WorkContext.Instance.CurrentlyLoggedOnUser.GroupType == UserGroupType.ProjectManager)
                ProjectAddButton.Visibility = Visibility.Visible;

            ReloadProjectList();
        }

        private void ReloadTaskList()
        {
            var selectedProject = ((GetProjectResponseItem)ProjectList.SelectedItem)?.Identifier;
            TaskList.ItemsSource = new Client().GetTask(new GetTaskRequest
            {
                ProjectIdentifiers = selectedProject != null ? new int[] { selectedProject.Value } : null
            }).Items;
        }

        private void ReloadProjectList()
        {
            ProjectList.ItemsSource = new Client().GetProject(new GetProjectRequest
            {
                SearchKeyword = SearchTxtBox.Text
            }).Items;
        }

        private void UserManageButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            App.Current.MainWindow = admin;
            admin.ShowDialog();
        }

        private void ProjectManageButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectManageWindow projectManageWindow =
                new ProjectManageWindow(((GetProjectResponseItem)ProjectList.SelectedItem).Identifier);
            App.Current.MainWindow = projectManageWindow;
            projectManageWindow.ShowDialog();

            ReloadProjectList();
        }

        private void ProjectAddButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectCreateWindow createProjectWindow = new ProjectCreateWindow();
            App.Current.MainWindow = createProjectWindow;
            createProjectWindow.ShowDialog();

            ReloadProjectList();
        }

        private void ProjectList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WorkContext.Instance.CurrentlyLoggedOnUser.GroupType == UserGroupType.ProjectManager)
            {
                if (ProjectList.SelectedItems.Count == 1)
                {
                    ProjectManageButton.Visibility = Visibility.Visible;
                    ProjectAddButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    ProjectManageButton.Visibility = Visibility.Hidden;
                    ProjectAddButton.Visibility = Visibility.Visible;
                }
            }

            ReloadTaskList();
        }

        private void SearchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadProjectList();
        }
    }
}