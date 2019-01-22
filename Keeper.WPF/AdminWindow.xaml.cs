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
    /// Logika interakcji dla klasy AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly Client _client;
        private GetUserResponseItem[] _users;

        public AdminWindow()
        {
            _client = new Client();
            _users = _client.GetUser(new GetUserRequest()).Items;
            InitializeComponent();
            var gridView = new GridView();
            this.UsersList.View = gridView;
            gridView.Columns.Add(new GridViewColumn { Header = "ID", DisplayMemberBinding = new Binding("id") });
            gridView.Columns.Add(new GridViewColumn { Header = "E-Mail", DisplayMemberBinding = new Binding("email") });
            gridView.Columns.Add(new GridViewColumn { Header = "Group", DisplayMemberBinding = new Binding("group") });
            foreach (var user in _users) {
                UsersList.Items.Add(new { email = user.Email, id = user.Identifier, group = user.Group }); }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow add = new AddUserWindow();
            add.Show();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {

            _client.DeleteUser(new DeleteUserRequest
            {
                Identifiers = UsersList.SelectedItems.Cast<UserListItemModel>().Select(aUser => aUser.Id).ToArray()
            });
            UsersList.Items.Clear();
            _users = _client.GetUser(new GetUserRequest { SearchKeyword = SearchTxtBox.Text }).Items;
            foreach (var user in _users)
            {
                UsersList.Items.Add(new { email = user.Email, id = user.Identifier, group = user.Group });
            }
        }
        
        private void UsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void SearchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsersList.Items.Clear();
           _users = _client.GetUser(new GetUserRequest { SearchKeyword = SearchTxtBox.Text}).Items;
            foreach (var user in _users)
            {
                UsersList.Items.Add(new { email = user.Email, id = user.Identifier, group = user.Group });
            }
        }
    }
}
