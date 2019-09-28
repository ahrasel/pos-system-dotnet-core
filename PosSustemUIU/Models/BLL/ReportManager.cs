using Microsoft.EntityFrameworkCore;
using PosSustemUIU.Data;
using PosSustemUIU.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosSustemUIU.Models.BLL
{
    public class ReportManager
    {
        string _purchaseId = "bda54eb3-c4ea-4a52-a488-9fdaf2bb6e8d";
        string _saleId = "9d87f732-8a45-478b-a725-1d566974f947";
        private readonly ApplicationDbContext _context;
        public ReportManager(ApplicationDbContext context)
        {
            _context = context;
        }

        internal async Task<List<Transection>> getProductReportAsync()
        {
            return await _context.Transections.Where(t => t.TransectionTypeId == _purchaseId).Include(t => t.Product).Include(t => t.TransectionType).ToListAsync();
        }

        internal async Task<List<Transection>> getSaleReportAsync()
        {
            return await _context.Transections.Where(t => t.TransectionTypeId == _saleId).Include(t => t.Product).Include(t => t.TransectionType).ToListAsync();
        }

        internal async Task<List<Transection>> getPurchaseReportAsync()
        {
            return await _context.Transections.Where(t => t.TransectionTypeId == _purchaseId).Include(t => t.Product).Include(t => t.TransectionType).ToListAsync();
        }

        internal async Task<List<CustomerReportVM>> getCustomerReportAsync()
        {
            var sales = await _context.ProductSales.Include(s => s.Customer).Include(s => s.TransectionType).ToListAsync();
            var transections = await getSaleReportAsync();
            
            var list = new List<CustomerReportVM>();

            foreach (var sale in sales)
            {
                foreach (var transection in transections)
                {
                    if (sale.Id == transection.ParentId)
                    {
                        list.Add(
                            new CustomerReportVM
                            { 
                                CustomerName = sale.Customer.FullName,
                                ProductName = transection.Product.Name,
                                Quantity = transection.Quantity,
                                Price = transection.Price,
                                SaleDate = sale.SaleDate,
                            }
                        );
                    }
                }
            }

            return list;
        }

        internal async Task<List<SupplierReportVM>> getSupplierReportAsync()
        {
            var sales = await _context.ProductPurchases.Include(s => s.Supplier).Include(s => s.TransectionType).ToListAsync();
            var transections = await getPurchaseReportAsync();

            var list = new List<SupplierReportVM>();

            foreach (var sale in sales)
            {
                foreach (var transection in transections)
                {
                    if (sale.Id == transection.ParentId)
                    {
                        list.Add(
                            new SupplierReportVM
                            {
                                SupplierName = sale.Supplier.Name,
                                ProductName = transection.Product.Name,
                                Quantity = transection.Quantity,
                                Price = transection.Price,
                                PurchaseDate = sale.PurchaseDate,
                            }
                        );
                    }
                }
            }

            return list;
        }
    }
}