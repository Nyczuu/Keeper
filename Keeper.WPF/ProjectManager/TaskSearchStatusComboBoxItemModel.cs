using Keeper.CoreContract.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keeper.WPF.ProjectManager
{
    public class TaskSearchStatusComboBoxItemModel
    {
        public int Identifier { get; private set; }
        public string Value { get; private set; }

        public TaskSearchStatusComboBoxItemModel(int identifier, string value)
        {
            Identifier = identifier;
            Value = value;
        }

        public TaskSearchStatusComboBoxItemModel(TaskStatus status)
        {
            Identifier = (int)status;
            Value = status.ToString();
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
