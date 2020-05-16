using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Buy_Stocks_Final_Project.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public int NumberOfTotalStocks { get; set; }

        public int StocksSold { get; set; }

        [NotMapped]
        public int AvailableStocks { get {

                return NumberOfTotalStocks - StocksSold;
            } }

        public decimal StockPrice { get; set; }

    }
}
