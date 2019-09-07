using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PosSustemUIU.Data;
using PosSustemUIU.Models;

namespace PosSustemUIU.Controllers
{
    public class ProductSaleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductSaleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductSale
        public async Task<IActionResult> Index()
        {
            var productSales = _context.ProductSales.Include(p => p.Customer).Include(p => p.TransectionType);
            return View(await productSales.ToListAsync());
        }

        // GET: ProductSale/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSale = await _context.ProductSales
                .Include(p => p.Customer)
                .Include(p => p.TransectionType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productSale == null)
            {
                return NotFound();
            }

            return View(productSale);
        }

        // GET: ProductSale/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Customers = await _context.Customers.ToListAsync();
            // ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            // ViewData["TransectionTypeOId"] = new SelectList(_context.TransectionType, "Id", "Id");
            return View();
        }

        // POST: ProductSale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReferenceInternal,ReferenceExternal,SaleDate,PostingDate,TotalPrice,TotalVat,TotalDiscount,TotalQuantity,Note,PaymentNote,IsVatPaid,ReceivingCost,IsActive,Meta,CustomerMeta,IsDeleted,CreatedBy,UpdatedBy,DeletedBy,CreatedAt,DeletedAt,CustomerId,TransectionTypeOId")] ProductSale productSale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", productSale.CustomerId);
            ViewData["TransectionTypeOId"] = new SelectList(_context.TransectionType, "Id", "Id", productSale.TransectionTypeOId);
            return View(productSale);
        }

        // GET: ProductSale/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSale = await _context.ProductSales.FindAsync(id);
            if (productSale == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", productSale.CustomerId);
            ViewData["TransectionTypeOId"] = new SelectList(_context.TransectionType, "Id", "Id", productSale.TransectionTypeOId);
            return View(productSale);
        }

        // POST: ProductSale/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,ReferenceInternal,ReferenceExternal,SaleDate,PostingDate,TotalPrice,TotalVat,TotalDiscount,TotalQuantity,Note,PaymentNote,IsVatPaid,ReceivingCost,IsActive,Meta,CustomerMeta,IsDeleted,CreatedBy,UpdatedBy,DeletedBy,CreatedAt,DeletedAt,CustomerId,TransectionTypeOId")] ProductSale productSale)
        {
            if (id != productSale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productSale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSaleExists(productSale.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", productSale.CustomerId);
            ViewData["TransectionTypeOId"] = new SelectList(_context.TransectionType, "Id", "Id", productSale.TransectionTypeOId);
            return View(productSale);
        }

        // GET: ProductSale/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSale = await _context.ProductSales
                .Include(p => p.Customer)
                .Include(p => p.TransectionType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productSale == null)
            {
                return NotFound();
            }

            return View(productSale);
        }

        // POST: ProductSale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var productSale = await _context.ProductSales.FindAsync(id);
            _context.ProductSales.Remove(productSale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSaleExists(string id)
        {
            return _context.ProductSales.Any(e => e.Id == id);
        }
    }
}
