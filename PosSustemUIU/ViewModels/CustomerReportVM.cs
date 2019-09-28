using System;

namespace PosSustemUIU.ViewModels
{
    public class CustomerReportVM
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }


    }
}