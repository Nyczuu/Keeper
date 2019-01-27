using Keeper.Core;
using Keeper.CoreContract.Users;
using Keeper.WPF.Admin;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Keeper.WPF.ProjectManager
{
    /// <summary>
    /// Logika interakcji dla klasy InvolvedUsersWindow.xaml
    /// </summary>
    public partial class InvolvedUsersWindow : Window
    {
        public InvolvedUsersWindow(int ProjectId)
        {
            InitializeComponent();
            ReloadUsersList();
        }
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            var add = new ManageProjectUsersWindow();
            add.ShowDialog();
            ReloadUsersList();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadUsersList();
        }

        private void SearchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadUsersList();
        }

        private void ReloadUsersList()
        {
            var users = new Client().GetUser(new GetUserRequest
            {
                SearchKeyword = SearchTxtBox.Text,
                
            }).Items;
            UserList.ItemsSource = users.Select(aUser
                => new UserListItemModel
                {
                    Id = aUser.Identifier,
                    Email = aUser.Email,
                    Group = aUser.Group,
                }).ToList();
        }
    }
}
