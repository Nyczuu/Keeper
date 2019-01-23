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
            if (WorkContext.Instance.CurrentlyLoggedOnUser.GroupType == UserGroupType.Administrator) {
               //admin moze grzebac w projektach wiec go nie ukrywam u niego
            }
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
            ProjectManagerWindow pMWindow = new ProjectManagerWindow();
            App.Current.MainWindow = pMWindow;
            pMWindow.ShowDialog();
        }


        private void ProjectList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ReloadTaskList(ProjectList.SelectedIndex);
        }

        private void ReloadTaskList(int ProjectId)
        {
            //GetTask(ProjectId);
        }

        private void ReloadProjectList()
        {
            //GetProjects();
        }

    }
}
