using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            if (userType == 0) // user gui
            {
                manage_users_but.Visibility = Visibility.Hidden;
                project_edit_but.Visibility = Visibility.Hidden;
            }

            if (userType == 1) // user PM
            {
                manage_users_but.Visibility = Visibility.Hidden;
                
            }

            if (userType == 2) // user HR
            {
                project_edit_but.Visibility = Visibility.Hidden;
            }

        }

        private void Manage_Users_but_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            App.Current.MainWindow = admin;           
            admin.Show();
        }

        private int userType = 0;

        private void Project_Edit_but_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
