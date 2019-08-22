using Microsoft.AspNetCore.Hosting;
using PosSustemUIU.Data;
using PosSustemUIU.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PosSustemUIU.Models;

namespace PosSustemUIU.Models.BLL
{
    public class ProductManager
    {
        private readonly ApplicationDbContext _context;

        public ProductManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveProductAsync(ProductVM productVM){

            var product = new Product
            {
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
                CreatedBy = productVM.CreatedBy,
                CreatedAt = DateTime.Now,
            };

            _context.Add(product);
            //save barcode
            _context.Add(new ProductBarcode{
                Barcode = productVM.Barcode,
                ProductId = product.Id,
                CreatedBy = productVM.CreatedBy,
                IsActive = true,
                CreatedAt = DateTime.Now
            });
            //save vat
            _context.Add(new ProductVat
            {
                Vat = productVM.Vat,
                ProductId = product.Id,
                CreatedBy = productVM.CreatedBy,
                IsActive = true,
                CreatedAt = DateTime.Now
            });
            //save price
            _context.Add(new ProductPrice
            {
                Price = productVM.Price,
                ProductId = product.Id,
                CreatedBy = productVM.CreatedBy,
                IsActive = true,
                CreatedAt = DateTime.Now
            });
            //save discount
            if (productVM.Discount > 0){}
            {
                _context.Add(new ProductDiscount
                {
                    Discount = productVM.Discount,
                    ProductId = product.Id,
                    CreatedBy = productVM.CreatedBy,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                });
            }

            //save unit
            _context.Add(new ProductUnit
            {
                UnitTypeId = productVM.UnitId,
                ProductId = product.Id,
                CreatedBy = productVM.CreatedBy,
                IsActive = true,
                CreatedAt = DateTime.Now
            });

            var res = await _context.SaveChangesAsync();

            return res > 0 ? true : false;
        }

    }
}