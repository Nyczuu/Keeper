using Keeper.Core;
using Keeper.CoreContract.Users;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Keeper.WPF.Admin
{
    /// <summary>
    /// Logika interakcji dla klasy AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();

            UserList.CanUserAddRows = false;
            UserList.CanUserDeleteRows = false;
            
            ReloadUsersList();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow add = new AddUserWindow();
            add.ShowDialog();
            ReloadUsersList();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if(UserList.SelectedItems.Count > 0)
            {
                new Client().DeleteUser(new DeleteUserRequest
                {
                    Identifiers = UserList.SelectedItems
                    .Cast<UserListItemModel>()
                    .Select(aSelectedItem => aSelectedItem.Id)
                    .ToArray()
                });
            }
            ReloadUsersList();
        }

        private void SearchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadUsersList();
        }

        private void ReloadUsersList()
        {
            var users = new Client().GetUser(new GetUserRequest { SearchKeyword = SearchTxtBox.Text }).Items;
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