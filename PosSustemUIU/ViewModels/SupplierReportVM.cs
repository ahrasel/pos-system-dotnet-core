using System;

namespace PosSustemUIU.ViewModels
{
    public class SupplierReportVM
    {
        public string SupplierName { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }


    }
}