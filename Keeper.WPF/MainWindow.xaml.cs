using Keeper.Core;
using Keeper.CoreContract.Users;
using Keeper.WPF.Admin;
using System;
using System.Windows;
using System.Windows.Input;

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
            Login();
        }

        private void Password_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                Login();
        }

        private void Login()
        {
            var loginUserResponse = new Client().LoginUser(new LoginUserRequest
            {
                Email = Login_TxtBox.Text,
                Password = Password_Box.Password,
            });

            if (loginUserResponse == null)
                Message_TxtBlock.Text = Strings.Common_DefaultError;

            else
            {
                switch (loginUserResponse.Type)
                {
                    case LoginUserResponseType.NoUser:
                        { Message_TxtBlock.Text = Strings.LoginUser_NoUser; }
                        break;
                    case LoginUserResponseType.WrongEmail:
                        { Message_TxtBlock.Text = Strings.LoginUser_WrongEmail; }
                        break;
                    case LoginUserResponseType.WrongPassword:
                        { Message_TxtBlock.Text = Strings.LoginUser_WrongPassword; }
                        break;
                    case LoginUserResponseType.Success:
                        { Run(loginUserResponse.SessionKey); }
                        break;
                    default:
                        { Message_TxtBlock.Text = Strings.Common_DefaultError; }
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
                var window = new UserWindow();
                App.Current.MainWindow = window;
                this.Close();
                window.Show();
            }
        }
    }
}
