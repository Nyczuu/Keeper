﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.CoreContract.Tasks
{
    public enum UpdateTaskResponseType
    {
        TaskDoesNotExist,
        NameEmpty,
        NameExists,
        ProjectDoesNotExist,
        Success,
    }
}
