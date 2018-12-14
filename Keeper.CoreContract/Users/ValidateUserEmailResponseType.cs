using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.CoreContract.Users
{
    public enum ValidateUserEmailResponseType
    {
        IsValid = 0,
        IsEmpty = 1,
        WrongFormat = 2,
        AlreadyExists = 3,
    }
}
