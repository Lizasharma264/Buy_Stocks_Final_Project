using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Buy_Stocks_Final_Project.Models
{
    public class StocksPayment
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public int StocksBuyerId { get; set; }

        public Company Company { get; set; }

        public StocksBuyer StocksBuyer { get; set; }

        public int NumberOfStocks { get; set; }

        [NotMapped]
        public decimal PurchasedStocksValue { get {

                return NumberOfStocks * Company.StockPrice;


            } }




    }
}
