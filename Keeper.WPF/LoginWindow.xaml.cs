using Keeper.Core;
using Keeper.CoreContract.Users;
using Keeper.WPF.Admin;
using System;
using System.Windows;
using System.Windows.Input;

namespace Keeper.WPF
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void LoginPasswordPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                Login();
        }

        private void Login()
        {
            var loginUserResponse = new Client().LoginUser(new LoginUserRequest
            {
                Email = LoginEmailTextBox.Text,
                Password = LoginPasswordPasswordBox.Password,
            });

            if (loginUserResponse == null)
                LoginValidationMessageTextBlock.Text = Strings.Common_DefaultError;

            else
            {
                switch (loginUserResponse.Type)
                {
                    case LoginUserResponseType.NoUser:
                        { LoginValidationMessageTextBlock.Text = Strings.LoginUser_NoUser; }
                        break;
                    case LoginUserResponseType.WrongEmail:
                        { LoginValidationMessageTextBlock.Text = Strings.LoginUser_WrongEmail; }
                        break;
                    case LoginUserResponseType.WrongPassword:
                        { LoginValidationMessageTextBlock.Text = Strings.LoginUser_WrongPassword; }
                        break;
                    case LoginUserResponseType.Success:
                        { Run(loginUserResponse.SessionKey); }
                        break;
                    default:
                        { LoginValidationMessageTextBlock.Text = Strings.Common_DefaultError; }
                        break;
                }
            }
        }

        private void Run(Guid sessionKey)
        {
            var getUserSessionResponse = new Client().GetUserSession(
                new GetUserSessionRequest { SessionKey = sessionKey });

            if(getUserSessionResponse != null)
            {
                WorkContext.Instance.Initialize(getUserSessionResponse);
                var window = new DashboardWindow();
                App.Current.MainWindow = window;
                Close();
                window.Show();
            }
        }
    }
}
