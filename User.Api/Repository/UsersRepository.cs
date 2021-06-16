using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Api.DbContexts;
using User.Api.Entities;
using User.Api.Models;

namespace User.Api.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private UsersContext _context;
        private IAuthentication _localAuth;
        public UsersRepository(UsersContext context, IAuthentication localAuth)
        {
            _context = context;
            _localAuth = localAuth;
        }

        public string AdminLogIn(UsersModel admin)
        {
            var logger = _context.Users.FirstOrDefault(u => u.UserName == admin.UserName);
            if (logger!=null && logger.UserType.ToLower() == "user")
            {
                return "LogIn with Admin";
            }
            var pres = _context.LoggedInUsers.FirstOrDefault(u => u.UserID == admin.UserName);
            if (pres == null)
            {
                if (_localAuth.checkUser(admin))
                {
                    _context.LoggedInUsers.Add(new LoggedInUsers() { UserID=admin.UserName});
                    _context.SaveChanges();
                    return "Admin LogIn Success";
                }
                return "Check Password";
            }
            return "Already LoggedIn";
        }

        public string LogOut(UsersModel user)
        {
            var pres = _context.LoggedInUsers.FirstOrDefault(u => u.UserID == user.UserName);
            if (pres != null)
            {
                _context.LoggedInUsers.Remove(pres);
                _context.SaveChanges();
                return "LogOut Success";
            }
            return "You are not LoggedIn";
        }

        public string UserLogIn(UsersModel user)
        {
            var logger = _context.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (logger == null)
            {
                return "You need to signUp";
            }
            if (logger.UserType.ToLower() == "admin")
            {
                return "LogIn with Admin";
            }
            var pres = _context.LoggedInUsers.FirstOrDefault(u => u.UserID == user.UserName);
            if (pres == null)
            {
                if (_localAuth.checkUser(user))
                {
                    var token = _localAuth.validateUser(logger);
                    _context.LoggedInUsers.Add(new LoggedInUsers() { UserID = user.UserName });
                    _context.SaveChanges();
                   return token;
                }
                return "Check Password or register";
            }
            return "Already LoggedIn";
        }

        public string UserSignUp(Users user)
        {
            var token = _localAuth.validateUser(user);
            if (token!= "Enter valid username")
            {
                if (user.UserType.ToLower() == "user")
                {
                    user.Password = _localAuth.validateUser(user);
                    _context.Add(user);
                    _context.SaveChanges();
                    return token;
                }
                return "You can not sign up as admin";
            }
            return "Not valid details";
        }

        public string Try(Users user)
        {
            return _localAuth.validateUser(user);
        }

    }
}