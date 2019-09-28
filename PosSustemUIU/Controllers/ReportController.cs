using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PosSustemUIU.Data;
using PosSustemUIU.Models;
using PosSustemUIU.Models.BLL;

namespace PosSustemUIU.Controllers
{
    // [Authorize(Roles = "Administrator")]
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ReportManager _manager;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
            _manager = new ReportManager(context);
        }

        
        public async Task<IActionResult> ProductReport()
        {
            return View(await _manager.getProductReportAsync());
        }

        // public async Task<IActionResult> ProductCategoriesReport()
        // {
        //     return View(await _context.Areas.ToListAsync());
        // }

        public async Task<IActionResult> SaleReport()
        {
            return View(await _manager.getSaleReportAsync());
        }

        public async Task<IActionResult> PurchaseReport()
        {
            return View(await _manager.getPurchaseReportAsync());
        }

        public async Task<IActionResult> CustomerReport()
        {
            return View(await _manager.getCustomerReportAsync());
        }

        public async Task<IActionResult> SupplierReport()
        {
            return View(await _manager.getSupplierReportAsync());
        }
       

    }
}
