using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using User.Api.DbContexts;
using User.Api.Entities;
using User.Api.Models;
using User.Api.Repository;

namespace User.Api
{
    public class Authentication:IAuthentication
    {
        private UsersContext _context;
        public Authentication(UsersContext context)
        {
            _context = context;
        }

        public bool checkUser(UsersModel user)
        {
            var realUser = _context.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (realUser != null)
            {
                if (realUser.Password == user.Password)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool validateUser(Users user)
        {
            var userNameValidation = Regex.IsMatch(user.UserName, @"^[A-Z]{2}$");
            if (!userNameValidation)
            {
                return true;
            }
            return false;
        }
    }
}