using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Buy_Stocks_Final_Project.Models;

namespace Buy_Stocks_Final_Project.Models
{
    public class Buy_Stocks_DBContext : DbContext
    {
        public Buy_Stocks_DBContext (DbContextOptions<Buy_Stocks_DBContext> options)
            : base(options)
        {
        }

        public DbSet<Buy_Stocks_Final_Project.Models.Company> Company { get; set; }

        public DbSet<Buy_Stocks_Final_Project.Models.StocksBuyer> StocksBuyer { get; set; }

        public DbSet<Buy_Stocks_Final_Project.Models.StocksPayment> StocksPayment { get; set; }
    }
}
