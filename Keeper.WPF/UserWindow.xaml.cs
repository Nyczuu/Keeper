using Keeper.Core;
using Keeper.CoreContract.Projects;
using Keeper.CoreContract.Tasks;
using Keeper.CoreContract.Users;
using Keeper.WPF.Admin;
using Keeper.WPF.ProjectManager;
using System.Windows;

namespace Keeper.WPF
{
    /// <summary>
    /// Logika interakcji dla klasy UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            if (WorkContext.Instance.CurrentlyLoggedOnUser.GroupType == UserGroupType.ProjectManager) {
                manage_users_but.Visibility = Visibility.Hidden;
            }
            if (WorkContext.Instance.CurrentlyLoggedOnUser.GroupType == UserGroupType.Worker) {
                project_edit_but.Visibility = Visibility.Hidden;
                manage_users_but.Visibility = Visibility.Hidden;
            }
            ReloadProjectList();
        }

        private void Manage_Users_but_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            App.Current.MainWindow = admin;           
            admin.ShowDialog();
        }

        private void Project_Edit_but_Click(object sender, RoutedEventArgs e)
        {
            ProjectManagerWindow projectManagerWindow = new ProjectManagerWindow();
            App.Current.MainWindow = projectManagerWindow;
            projectManagerWindow.ShowDialog();
        }

        private void ProjectList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ReloadTaskList();
        }

        private void ReloadTaskList()
        {
            TaskList.ItemsSource = new Client().GetTask(new GetTaskRequest
            {
                ProjectIdentifiers = new int[] 
                {
                    ((GetProjectResponseItem)ProjectList.SelectedItem).Identifier,
                }
            }).Items;
        }

        private void ReloadProjectList()
        {
            ProjectList.ItemsSource = new Client().GetProject(new GetProjectRequest
            {
                SearchKeyword = SearchProjectTxtBox.Text
            }).Items;
        }

        private void SearchProjectTxtBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ReloadProjectList();
        }

        private void OpenLogButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new TaskWindow();
            App.Current.MainWindow = window;
            window.ShowDialog();
        }
    }
}
