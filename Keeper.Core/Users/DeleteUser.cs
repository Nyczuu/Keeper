﻿using Keeper.CoreContract.Users;
using Keeper.Data;
using Keeper.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Core.Users
{
    public class DeleteUser
    {
        public DeleteUserResponse Response { get; private set; }

        public DeleteUser(DeleteUserRequest request)
        {
            if(request != null && request.Identifiers != null && request.Identifiers.Any())
            {
                using(var dbContext = new ApplicationDbContext())
                {
                    var usersToDelete = dbContext.Users.Where(aUser
                        => request.Identifiers.Contains(aUser.Identifier));

                    dbContext.Users.RemoveRange(usersToDelete);
                    dbContext.SaveChanges();
                }

                Response = new DeleteUserResponse();
            }
        }
    }
}
