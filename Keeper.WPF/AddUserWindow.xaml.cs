using Keeper.Core;
using Keeper.CoreContract.Users;
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
    /// Logika interakcji dla klasy AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client();
            var response = client.CreateUser(new CreateUserRequest
            {
                Email = EmailTextBox.Text,
                Password = PassWordTextBox.Text,
                Group =UserGroupType.Administrator
            });

            if (response.Type == CreateUserResponseType.Success)
            {
                this.Close();
            }
            else
            {
                ErrorTxtBlock.Text = "Add User Failed";
            }
            /*
              if(AddUserResponse.Success){
                new AddUserRequest(EmailTextBox.Text, PassWordTextBox.Text);
              this.Close();
              */
            
        }

        private void PassWordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        /*else{
* ErrorTxtBlock.Text = "Add User Failed";
}
*/

    }
}
