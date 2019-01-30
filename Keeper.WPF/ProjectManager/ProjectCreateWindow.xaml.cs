using Keeper.Core;
using Keeper.CoreContract.Projects;
using System.Windows;

namespace Keeper.WPF.ProjectManager
{
    /// <summary>
    /// Logika interakcji dla klasy AddProjectWindow.xaml
    /// </summary>
    public partial class ProjectCreateWindow : Window
    {
        public ProjectCreateWindow()
        {
            InitializeComponent();
        }

        private void ProjectCreateButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client();
            var response = client.CreateProject(new CreateProjectRequest
            {
                Name = ProjectCreateNameTextBox.Text
            });

            if (response == null)
            {
                ProjectCreateValidationMessageTextBlock.Text = Strings.Common_DefaultError;
                return;
            }

            switch (response.Type)
            {
                case CreateProjectResponseType.NameEmpty:
                    { ProjectCreateValidationMessageTextBlock.Text = Strings.AddProject_NameEmpty; }
                    break;
                case CreateProjectResponseType.NameExists:
                    { ProjectCreateValidationMessageTextBlock.Text = Strings.Add_Project_NameExists; }
                    break;
                case CreateProjectResponseType.Success:
                    { Close(); }
                    break;
                default: { ProjectCreateValidationMessageTextBlock.Text = Strings.Common_DefaultError; } break;
            }
        }
    }
}
