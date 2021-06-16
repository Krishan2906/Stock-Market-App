using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Api.Entities;
using User.Api.Models;

namespace User.Api.Repository
{
    public interface IAuthentication
    {
        public bool checkUser(UsersModel user);
        string validateUser(Users user);

        //string GenerateJSONWebToken(string username);
    }
}
