using Stock.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Api.Repository
{
    public interface IStocksRepository
    {
        List<StockExchanges> getStockExchangesList();
        void addStockExchange(StockExchanges stockExchange);

        List<Companies> getCompaniesList(int id);

    }
}