using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Api.Entities
{
    public class Test2
    {
        public int Id { get; set; }

        public string Dean { get; set; }

        public string CollegeName { get; set; }

        public List<Test1> Students { get; set; }

    }
}
