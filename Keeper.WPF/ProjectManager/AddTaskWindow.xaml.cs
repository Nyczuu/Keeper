using Keeper.Core;
using Keeper.CoreContract.Tasks;
using System.Windows;

namespace Keeper.WPF.ProjectManager
{
    /// <summary>
    /// Logika interakcji dla klasy AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        private readonly int _projectIdentifier;

        public AddTaskWindow(int projectIdentifier)
        {
            InitializeComponent();
            _projectIdentifier = projectIdentifier;
        }

        private void TaskAddButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client();
            var response = client.CreateTask(new CreateTaskRequest
            {
                ProjectIdentifier = _projectIdentifier,
                Name = TaskAddNameTextBox.Text,
                Description = TaskAddDescriptionTextBox.Text,
            });

            if (response == null)
            {
                TaskAddValidationMessageTextBlock.Text = Strings.Common_DefaultError;
                return;
            }

            switch (response.Type)
            {
                case CreateTaskResponseType.NameEmpty:
                    { TaskAddValidationMessageTextBlock.Text = Strings.AddProject_NameEmpty; }
                    break;
                case CreateTaskResponseType.NameExists:
                    { TaskAddValidationMessageTextBlock.Text = Strings.Add_Project_NameExists; }
                    break;
                case CreateTaskResponseType.ProjectDoesNotExist:
                    { TaskAddValidationMessageTextBlock.Text = Strings.Add_Project_NameExists; }
                    break;
                case CreateTaskResponseType.Success:
                    { Close(); }
                    break;
                default:
                    { TaskAddValidationMessageTextBlock.Text = Strings.Common_DefaultError; }
                    break;
            }
        }
    }
}
