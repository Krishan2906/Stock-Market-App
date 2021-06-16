using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Api.Entities;
using User.Api.Models;

namespace User.Api.Repository
{
    public interface IUsersRepository
    {
        public string UserLogIn(UsersModel user);
        public string UserSignUp(Users user);
        public string AdminLogIn(UsersModel admin);
        public string LogOut(UsersModel admin);

        //
        public string Try(Users user);

    }
}
