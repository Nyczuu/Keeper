using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.WPF.ProjectManager
{
    public class TaskCreateAssigneeComboBoxItemModel
    {
        public int Identifier { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Email;
        }
    }
}
