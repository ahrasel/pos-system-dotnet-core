using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PosSustemUIU.Data;
using PosSustemUIU.Models;
using PosSustemUIU.ViewModels;

namespace PosSustemUIU.Controllers
{
    public class ProductController : BaseCotroller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _environment;

        public ProductController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productVM = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productVM == null)
            {
                return NotFound();
            }

            return View(productVM);
        }

        // GET: Product/Create
        public async Task<IActionResult> Create()
        {   
            return View(await GetProductVMAsync());
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Image,KeyWord,Code,ExpireDate,IsActive,Meta,IsDeleted,ProductCategoryID,SupplierId,BrandId,ProductGroupID")] ProductVM productVM)
        {
            if (ModelState.IsValid)
            {

                var files = HttpContext.Request.Form.Files;
                if (files != null)
                {
                    var fileNames = UploadFiles(_environment, files, "customers");
                    if (fileNames.Count > 0)
                    {
                        productVM.Image = fileNames[0];
                    }
                }


                var product = new Product{
                    Name = productVM.Name,
                    Description = productVM.Description,
                    Image = productVM.Image,
                    KeyWord = productVM.KeyWord,
                    Code = productVM.Code,
                    ExpireDate = productVM.ExpireDate,
                    IsActive = productVM.IsActive,
                    Meta = productVM.Meta,
                    ProductCategoryID = productVM.ProductCategoryID,
                    SupplierId = productVM.SupplierId,
                    BrandId = productVM.BrandId,
                    ProductGroupID = productVM.ProductGroupID,
                    CreatedBy = GteUserId(),
                    CreatedAt =DateTime.Now,
                };

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            productVM.Categories = await _context.ProductCategories.Where(c => c.IsActive == true).ToListAsync();
            productVM.Suppliers = await _context.Suppliers.Where(s => s.IsActive == true).ToListAsync();
            productVM.Suppliers = await _context.Suppliers.Where(s => s.IsActive == true).ToListAsync();
            productVM.Brands = await _context.Brands.Where(b => b.IsActive == true).ToListAsync();
            productVM.Brands = await _context.Brands.Where(b => b.IsActive == true).ToListAsync();
            productVM.ProductGroups = await _context.ProductGroups.Where(g => g.IsActive == true).ToListAsync();
            productVM.UnitTypes = await _context.UnitTypes.Where(g => g.IsActive == true).ToListAsync();

            return View(productVM);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productVM = await _context.Products.FindAsync(id);
            if (productVM == null)
            {
                return NotFound();
            }
            
            return View(productVM);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,Image,KeyWord,Code,ExpireDate,IsActive,Meta,IsDeleted,ProductCategoryID,SupplierId,BrandId,ProductGroupID,CreatedBy,UpdatedBy,DeletedBy,CreatedAt,DeletedAt")] ProductVM productVM)
        {
            if (id != productVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(productVM.Id))
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
            return View(productVM);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productVM = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productVM == null)
            {
                return NotFound();
            }

            return View(productVM);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var productVM = await _context.Products.FindAsync(id);
            _context.Products.Remove(productVM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(string id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        private async Task<ProductVM> GetProductVMAsync(){
            var product = new ProductVM();
            product.Categories = await _context.ProductCategories.Where(c => c.IsActive == true).ToListAsync();
            product.Suppliers = await _context.Suppliers.Where(s => s.IsActive == true).ToListAsync();
            product.Suppliers = await _context.Suppliers.Where(s => s.IsActive == true).ToListAsync();
            product.Brands = await _context.Brands.Where(b => b.IsActive == true).ToListAsync();
            product.Brands = await _context.Brands.Where(b => b.IsActive == true).ToListAsync();
            product.ProductGroups = await _context.ProductGroups.Where(g => g.IsActive == true).ToListAsync();
            product.UnitTypes = await _context.UnitTypes.Where(g => g.IsActive == true).ToListAsync();

            return product;
        }

        public override async Task<IActionResult> ChangeActiveStatus(string id)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
        
            var product = await GetProductById(id);
            product.IsActive = !product.IsActive;
            product.UpdatedBy = GteUserId();
            _context.Update(product);
            await _context.SaveChangesAsync();
        
            return RedirectToAction(nameof(Index));
        }
        
        public override async Task<IActionResult> SoftDelete(string id)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
        
            var product = await GetProductById(id);
            product.IsDeleted = !product.IsDeleted;
            product.UpdatedBy = GteUserId();
            product.DeletedBy = GteUserId();
            product.DeletedAt = DateTime.Now;
            _context.Update(product);
            await _context.SaveChangesAsync();
        
            return RedirectToAction(nameof(Index));
        }
        
        public override async Task<IActionResult> Restore(string id)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
        
            var product = await GetProductById(id);
            product.IsDeleted = !product.IsDeleted;
            product.UpdatedBy = GteUserId();
            _context.Update(product);
            await _context.SaveChangesAsync();
        
            return RedirectToAction(nameof(Index));
        }
        
        
        private async Task<Product> GetProductById(string id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }
    }
}
