using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User.Api.Entities
{

    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        //public string EMail { get; set; }
        public long MobileNo { get; set; }
        public bool Confirmed { get; set; }

    }
}
