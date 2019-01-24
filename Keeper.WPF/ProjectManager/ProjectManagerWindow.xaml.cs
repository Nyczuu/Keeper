using Keeper.Core;
using Keeper.CoreContract.Projects;
using Keeper.CoreContract.Tasks;
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
    /// Logika interakcji dla klasy PMWindow.xaml
    /// </summary>
    public partial class ProjectManagerWindow : Window
    {
        public ProjectManagerWindow()
        {
            InitializeComponent();
            ProjectList.CanUserAddRows = false;
            ProjectList.CanUserDeleteRows = false;
            ProjectList.IsReadOnly = true;
            ReloadProjectList();
            
        }

      
        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            AddProjectWindow add = new AddProjectWindow();
            add.ShowDialog();
            ReloadProjectList();
        }

        private void DelProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if(ProjectList.SelectedItems.Count > 0)
            {

                new Client().DeleteProject(new DeleteProjectRequest
                {
                    Identifiers = ProjectList.SelectedItems
                    .Cast<ProjectListItemModel>()
                    .Select(aSelectedItem => aSelectedItem.Id).ToArray()
                });
            }
            ReloadProjectList();
        }

        private void InvolvedUsersButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectList.SelectedItems.Count ==1)
            {
                InvolvedUsersWindow window = new InvolvedUsersWindow(ProjectList.SelectedItems
                    .Cast<ProjectListItemModel>()
                    .Select(aSelectedItem => aSelectedItem.Id).ToArray());
                window.ShowDialog();
            }
            
            ReloadProjectList();
        }

        private void ReloadProjectList()
        {
            var projects = new Client().GetProject(new GetProjectRequest
            {
                SearchKeyword = SearchTxtBox.Text
            }).Items;
            ProjectList.ItemsSource = projects.Select(aProj =>
            new ProjectListItemModel
            {
                Id = aProj.Identifier,
                Name = aProj.Name,
                TasksCount = aProj.TasksCount
            }).ToList();
        }

        private void SearchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadProjectList();
        }
    }
}
