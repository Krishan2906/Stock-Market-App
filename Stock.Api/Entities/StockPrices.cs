using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Api.Entities
{
    public class StockPrices
    {
        public int StockExchangeId { get; set; }
        public StockExchanges StockExchanges { get; set; }

        public int CompanyStockCode { get; set; }
        public Companies Companies { get; set; }


        public float CurrentPrice { get; set; }

        public DateTime FullDateTime { get; set; }
        public DateTime Date
        {
            get
            {
                return FullDateTime.Date;
            }
        }
        public TimeSpan Time
        {
            get
            {
                return FullDateTime.TimeOfDay;
            }
        }

    }
}