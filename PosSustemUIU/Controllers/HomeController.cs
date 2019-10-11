using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PosSustemUIU.Data;
using PosSustemUIU.Models;
using PosSustemUIU.ViewModels;

namespace PosSustemUIU.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // [Route("/dashboard")]
        public IActionResult Index()
        {
            var homeVM = new HomeVM();
            homeVM.TotalCustomer =  _context.Customers.Count(c => c.IsActive == true);
            homeVM.TotalEmployee =  _context.Users.Count(u => u.IsActive == true);
            homeVM.TodaysSale =  _context.Transections.Count(t => t.TransectionTypeId == "9d87f732-8a45-478b-a725-1d566974f947");
            homeVM.TodaysPurchase =  _context.Transections.Count(t => t.TransectionTypeId == "bda54eb3-c4ea-4a52-a488-9fdaf2bb6e8d");
            return View(homeVM);
        }
        [AllowAnonymous]
        [Route("/about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [AllowAnonymous]
        [Route("/contact")]

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        [AllowAnonymous]
        [Route("/privacy")]

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
