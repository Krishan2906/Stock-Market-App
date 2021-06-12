using Microsoft.EntityFrameworkCore;
using Stock.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Api.DbContexts
{
    public class StocksContext : DbContext
    {
        public StocksContext(DbContextOptions<StocksContext> options) : base(options)
        {

        }

        public DbSet<StockPrices> StockPrices { get; set; }
        public DbSet<StockExchanges> StockExchanges { get; set; }
        public DbSet<Companies> Comapnies { get; set; }
        public DbSet<Test1> Students { get; set; }      //for testing purpose
        public DbSet<Test2> College { get; set; }       //for testing purpose


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Defining key for stockprices
            modelBuilder.Entity<StockPrices>().HasKey(sp => new { sp.StockExchangeId, sp.CompanyStockCode });
            //Defining Many-Many relation between Companies and stockExchanges
            modelBuilder.Entity<StockPrices>().HasOne(sp => sp.StockExchanges).WithMany(se => se.StockPrices).HasForeignKey(sp => sp.StockExchangeId);
            modelBuilder.Entity<StockPrices>().HasOne(sp => sp.Companies).WithMany(c => c.StockPrices).HasForeignKey(sp => sp.CompanyStockCode);
        }
    }
}
