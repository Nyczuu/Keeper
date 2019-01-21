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

            switch (response.Type)
            {
                case CreateUserResponseType.EmailExists:
                    { ErrorTxtBlock.Text = "Email address already exists."; }
                    break;
                case CreateUserResponseType.EmailNotValid:
                    { ErrorTxtBlock.Text = "Email address is not valid."; }
                    break;
                case CreateUserResponseType.PasswordTooWeak:
                    { ErrorTxtBlock.Text = "Provided password is too weak."; }
                    break;
                case CreateUserResponseType.Success:
                    { this.Close(); }
                    break;
                default: { } break;
            }
        }
    }
}
