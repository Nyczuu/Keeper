using Keeper.Core;
using Keeper.CoreContract.Projects;
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
    /// Logika interakcji dla klasy AddProjectWindow.xaml
    /// </summary>
    public partial class AddProjectWindow : Window
    {
        public AddProjectWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client();
            var response = client.CreateProject(new CreateProjectRequest
            {
                Name = NameTxtBox.Text
            });

            if (response == null)
                ErrorTxtBlock.Text = Strings.Common_DefaultError;

            switch (response.Type)
            {
                case CreateProjectResponseType.NameEmpty:
                    { ErrorTxtBlock.Text = Strings.AddProject_NameEmpty; }
                    break;
                case CreateProjectResponseType.NameExists:
                    { ErrorTxtBlock.Text = Strings.Add_Project_NameExists; }
                    break;
                case CreateProjectResponseType.Success:
                    { this.Close(); }
                    break;
                default: { ErrorTxtBlock.Text = Strings.Common_DefaultError; } break;
            }
        }
    }
}
