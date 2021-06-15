using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User.Api.Entities
{
    public class LoggedInUsers
    {
        [Key]
        public string UserID { get; set; }
        public DateTime Time { get; set; }

    }
}
