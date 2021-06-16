using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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

        public string validateUser(Users user)
        {
            var userNameValidation = Regex.IsMatch(user.UserName, @"^[A-Z]{2}$");
            if (!userNameValidation)
            {
                return this.GenerateJSONWebToken(user.UserName);
            }
            return "Enter valid username";
        }

        private string GenerateJSONWebToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my custom security key for a user who log in"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Issuer", "Shiv"),
                new Claim("Admin", "true"),
                new Claim(JwtRegisteredClaimNames.UniqueName, username)
            };

            var token = new JwtSecurityToken("Shiv",
                "Shiv",
                claims,
                expires:DateTime.Now.AddDays(2),
                signingCredentials:credentials );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}