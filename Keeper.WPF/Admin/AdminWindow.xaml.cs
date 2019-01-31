using Keeper.Core;
using Keeper.CoreContract.Users;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Keeper.WPF.Extensions;

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
            UserList.SetDefaults();
            
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
                new Client().UserDelete(new UserDeleteRequest
                {
                    Identifiers = UserList.SelectedItems
                    .Cast<UserListItemModel>()
                    .Select(aSelectedItem => aSelectedItem.Identifier)
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
            var users = new Client().UserGet1(new UserGet1Request
            { SearchKeyword = SearchTxtBox.Text }).Items;

            UserList.ItemsSource = users.Select(aUser
                => new UserListItemModel
                {
                    Identifier = aUser.Identifier,
                    Email = aUser.Email,
                    Group = aUser.Group,
                }).ToList();
        }
    }
}