﻿using Keeper.CoreContract.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keeper.WPF.ProjectManager
{
    public class TaskSearchStatusComboBoxItemModel
    {
        public int Identifier { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
