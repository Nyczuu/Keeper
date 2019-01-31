using Keeper.Core;
using Keeper.CoreContract.Users;
using System;
using System.Windows;

namespace Keeper.WPF.Admin
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
            var response = client.UserCreate(new UserCreateRequest
            {
                Email = EmailTextBox.Text,
                Password = PassWordTextBox.Text,
                Group = (UserGroupType)UserTypeComboBox.SelectedItem,
            });

            if (response == null)
                ErrorTxtBlock.Text = Strings.Common_DefaultError;

            switch (response.Type)
            {
                case UserCreateResponseType.EmailExists:
                    { ErrorTxtBlock.Text = Strings.CreateUser_EmailExists; }
                    break;
                case UserCreateResponseType.EmailNotValid:
                    { ErrorTxtBlock.Text = Strings.CreateUser_EmailNotValid; }
                    break;
                case UserCreateResponseType.PasswordTooWeak:
                    { ErrorTxtBlock.Text = Strings.CreateUser_PasswordTooWeak; }
                    break;
                case UserCreateResponseType.Success:
                    { this.Close(); }
                    break;
                default: { ErrorTxtBlock.Text = Strings.Common_DefaultError; } break;
            }
        }
    }
}
