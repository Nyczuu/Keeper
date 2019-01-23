using Keeper.Core;
using Keeper.WPF.Admin;
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
                //project_edit_but.Visibility = Visibility.Hidden;
        }

        private void Manage_Users_but_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            App.Current.MainWindow = admin;           
            admin.Show();
        }


        private void Project_Edit_but_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReloadProjectList()
        {
            //ProjectList = new Client().
        }
    }
}
