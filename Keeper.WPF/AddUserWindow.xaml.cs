using Keeper.Core;
using Keeper.CoreContract.Users;
using System;
using System.Windows;

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
            UserTypeComboBox.ItemsSource = Enum.GetValues(typeof(UserGroupType));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client();
            var response = client.CreateUser(new CreateUserRequest
            {
                Email = EmailTextBox.Text,
                Password = PassWordTextBox.Text,
                Group = (UserGroupType)UserTypeComboBox.SelectedItem,
            });

            if (response == null)
                ErrorTxtBlock.Text = Strings.Common_DefaultError;

            switch (response.Type)
            {
                case CreateUserResponseType.EmailExists:
                    { ErrorTxtBlock.Text = Strings.CreateUser_EmailExists; }
                    break;
                case CreateUserResponseType.EmailNotValid:
                    { ErrorTxtBlock.Text = Strings.CreateUser_EmailNotValid; }
                    break;
                case CreateUserResponseType.PasswordTooWeak:
                    { ErrorTxtBlock.Text = Strings.CreateUser_PasswordTooWeak; }
                    break;
                case CreateUserResponseType.Success:
                    { this.Close(); }
                    break;
                default: { ErrorTxtBlock.Text = Strings.Common_DefaultError; } break;
            }
        }
    }
}
