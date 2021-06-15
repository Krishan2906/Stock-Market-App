using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Api.Entities;
using User.Api.Models;
using User.Api.Repository;

namespace User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersRepository _repo;

        public UsersController(IUsersRepository repo)
        {
            _repo = repo;
        }

        /*
        [HttpPost("try/{id}")]
        public ActionResult<LoggedInUsers> show(int id)
        {
            var lu = new LoggedInUsers() { UserID = "ka", Time = DateTime.Now };
            return Ok(lu);
        }
        */

        [HttpPost("/user/login")]
        public ActionResult<string> UserLogIn(UsersModel user)
        {
            return _repo.UserLogIn(user);
            //throw new NotImplementedException();
        }


        [HttpGet("/user/login")]
        public ActionResult<string> UserGetLogIn()
        {
            return "Login Success";
            //throw new NotImplementedException();
        }

        [HttpPost("/admin/login")]
        public ActionResult<string> AdminLogIn(UsersModel admin)
        {
            return _repo.AdminLogIn(admin);
            //throw new NotImplementedException();
        }

        [HttpPost("/logout")]
        public ActionResult<string> UserLogOut(UsersModel user)
        {
            return _repo.LogOut(user);
            //throw new NotImplementedException();
        }

        [HttpPost("/signup")]
        public ActionResult<string> SignUp(Users user)
        {
            return _repo.UserSignUp(user);
        }
    }
}
