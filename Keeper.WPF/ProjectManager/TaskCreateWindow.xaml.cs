using Keeper.Core;
using Keeper.CoreContract.Tasks;
using Keeper.CoreContract.Users;
using System.Linq;
using System.Windows;

namespace Keeper.WPF.ProjectManager
{
    /// <summary>
    /// Logika interakcji dla klasy AddTaskWindow.xaml
    /// </summary>
    public partial class TaskCreateWindow : Window
    {
        private readonly int _projectIdentifier;

        public TaskCreateWindow(int projectIdentifier)
        {
            InitializeComponent();
            _projectIdentifier = projectIdentifier;

            TaskCreateAssigneeComboBox.ItemsSource = new Client().GetUser(
                new GetUserRequest
                {
                    ProjectsIdentifiers = new int[] { _projectIdentifier },
                    UserGroup = UserGroupType.Worker,
                })?.Items?
                .Select(aUser =>
                new TaskCreateAssigneeComboBoxItemModel
                {
                    Email = aUser.Email,
                    Identifier = aUser.Identifier,
                });
        }

        private void TaskCreateButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client();
            var response = client.CreateTask(new CreateTaskRequest
            {
                ProjectIdentifier = _projectIdentifier,
                Name = TaskCreateNameTextBox.Text,
                Description = TaskCreateDescriptionTextBox.Text,
                CreatorIdentifier = WorkContext.Instance.CurrentlyLoggedOnUser.Identifier,
                AssigneeIdentifier = ((TaskCreateAssigneeComboBoxItemModel)TaskCreateAssigneeComboBox.SelectedItem).Identifier,
            });

            if (response == null)
            {
                TaskCreateValidationMessageTextBlock.Text = Strings.Common_DefaultError;
                return;
            }

            switch (response.Type)
            {
                case CreateTaskResponseType.NameEmpty:
                    { TaskCreateValidationMessageTextBlock.Text = Strings.AddProject_NameEmpty; }
                    break;
                case CreateTaskResponseType.NameExists:
                    { TaskCreateValidationMessageTextBlock.Text = Strings.Add_Project_NameExists; }
                    break;
                case CreateTaskResponseType.ProjectDoesNotExist:
                    { TaskCreateValidationMessageTextBlock.Text = Strings.Add_Project_NameExists; }
                    break;
                case CreateTaskResponseType.Success:
                    { Close(); }
                    break;
                default:
                    { TaskCreateValidationMessageTextBlock.Text = Strings.Common_DefaultError; }
                    break;
            }
        }
    }
}
