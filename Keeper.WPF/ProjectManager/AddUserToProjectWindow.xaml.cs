using Keeper.Core;
using Keeper.CoreContract.Users;
using Keeper.WPF.Admin;
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

namespace Keeper.WPF.ProjectManager
{
    /// <summary>
    /// Logika interakcji dla klasy AddUserToProjectWindow.xaml
    /// </summary>
    public partial class AddUserToProjectWindow : Window
    {
        public AddUserToProjectWindow()
        {
            InitializeComponent();
            ReloadUsersList();
        }

        private void SearchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadUsersList();
        }

        private void AddToProjectButton_Click(object sender, RoutedEventArgs e)
        {
           // AddUsersToProjectResponse.
        }
        private void ReloadUsersList()
        {
            var users = new Client().GetUser(new GetUserRequest
            {
                SearchKeyword = SearchTxtBox.Text
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
