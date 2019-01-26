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
            if (WorkContext.Instance.CurrentlyLoggedOnUser.GroupType == UserGroupType.ProjectManager)
            {
                UserEditButton.Visibility = Visibility.Hidden;
            }
            if (WorkContext.Instance.CurrentlyLoggedOnUser.GroupType == UserGroupType.Worker)
            {
                ProjEditButton.Visibility = Visibility.Hidden;
                UserEditButton.Visibility = Visibility.Hidden;
            }
            ReloadProjectList();
        }
      
        private void ReloadTaskList()
        {
            TaskList.ItemsSource = new Client().GetTask(new GetTaskRequest
            {
                ProjectIdentifiers = new int[]{ (ProjectList.SelectedIndex+1) }
            }).Items;
        }

        private void ReloadProjectList()
        {
            ProjectList.ItemsSource = new Client().GetProject(new GetProjectRequest
            {
                SearchKeyword = SearchTxtBox.Text
            }).Items;
        }

        private void OpenLogButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new TaskWindow();
            App.Current.MainWindow = window;
            window.ShowDialog();
        }
    
        private void UserEditButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            App.Current.MainWindow = admin;
            admin.ShowDialog();
        }

        private void ProjEditButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectManagerWindow pMWindow = new ProjectManagerWindow();
            App.Current.MainWindow = pMWindow;
            pMWindow.ShowDialog();
            ReloadProjectList();
        }

        private void ProjectList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ReloadTaskList();
        }

        private void SearchTxtBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ReloadProjectList();
        }
    }
}
