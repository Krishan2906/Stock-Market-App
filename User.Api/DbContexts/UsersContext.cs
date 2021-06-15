using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Api.Entities;

namespace User.Api.DbContexts
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<LoggedInUsers> LoggedInUsers { get; set; }

    }
}
