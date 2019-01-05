using Keeper.Core;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Keeper.WPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {

          /*   var response = Client.(Login_TxtBox.Text, Password_Box.Password);
             if (response.Success)
             {
                 Message_TxtBlock.Text = "Login Successful";
             }
             else
             {
                 Message_TxtBlock.Text = "Login Bad";
             }*/
            if (Login_TxtBox.Text == "admin" && Password_Box.Password == "admin")
            {
                Message_TxtBlock.Text = "Login Successful";
                AdminWindow admin = new AdminWindow();
                App.Current.MainWindow = admin;
                this.Close();
                admin.Show();
            }
            else
            {
                Message_TxtBlock.Text = "Bad Login";
            }
        }

        private void Password_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (Login_TxtBox.Text == "admin" && Password_Box.Password == "admin")
                {
                    Message_TxtBlock.Text = "Login Successful";
                    AdminWindow admin = new AdminWindow();
                    App.Current.MainWindow = admin;
                    this.Close();
                    admin.Show();
                }
                else
                {
                    Message_TxtBlock.Text = "Bad Login";
                }
            }
        }
    }
}
