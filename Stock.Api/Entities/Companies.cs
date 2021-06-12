using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Api.Entities
{
    public class Companies
    {
        [Key]
        public int CompanyStockCode { get; set; }

        public string CompanyName { get; set; }
        public float Turnover { get; set; }
        public string CEO { get; set; }


        //[NotMapped]
        //public List<string> BoadOfDirectors { get; set; }

        public string Sectors { get; set; }

        public string BriefWriteup { get; set; }

        public List<StockPrices> StockPrices { get; set; }

    }
}
