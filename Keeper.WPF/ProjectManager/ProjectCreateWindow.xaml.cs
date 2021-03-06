﻿using Keeper.Core;
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
            var response = client.ProjectCreate(new ProjectCreateRequest
            {
                Name = ProjectCreateNameTextBox.Text,
                CreatorIdentifier = WorkContext.Instance.CurrentlyLoggedOnUser.Identifier,
            });

            if (response == null)
            {
                ProjectCreateValidationMessageTextBlock.Text = Strings.Common_DefaultError;
                return;
            }

            switch (response.Type)
            {
                case ProjectCreateResponseType.NameEmpty:
                    { ProjectCreateValidationMessageTextBlock.Text = Strings.AddProject_NameEmpty; }
                    break;
                case ProjectCreateResponseType.NameExists:
                    { ProjectCreateValidationMessageTextBlock.Text = Strings.Add_Project_NameExists; }
                    break;
                case ProjectCreateResponseType.Success:
                    { Close(); }
                    break;
                default: { ProjectCreateValidationMessageTextBlock.Text = Strings.Common_DefaultError; } break;
            }
        }
    }
}
