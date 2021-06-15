using Stock.Api.DbContexts;
using Stock.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Api.Repository
{
    public class StocksRepository : IStocksRepository
    {
        private StocksContext _context;

        public StocksRepository(StocksContext context)
        {
            _context = context;
        }

        public void addStockExchange(StockExchanges stockExchange)
        {
            _context.Add(stockExchange);
            _context.SaveChanges();
        }

        public List<Companies> getCompaniesList(int id)
        {
            var companies = (from s in _context.StockPrices
                             where s.StockExchangeId == id
                             select s.Companies).ToList();
            return companies;
        }

        public List<StockExchanges> getStockExchangesList()
        {
            return _context.StockExchanges.ToList();
        }
    }
}
