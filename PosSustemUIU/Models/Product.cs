using System;
using System.ComponentModel.DataAnnotations;

namespace PosSustemUIU.Models {
    public class Product {
        [Key]
        public string Id { get; set; }

        [Required (ErrorMessage = "Product Name Required")]
        [Display (Name = "Product Name")]
        [MaxLength (50)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Product Price")]
        public double Price { get; set; }
        [Display(Name = "Product Vat")]
        public double Vat { get; set; }
        [Display(Name = "Product Unit")]
        public double Unit { get; set; }
        [Display(Name = "Product Description")]
        public string Description { get; set; }
        [Display(Name = "Product Image")]
        public string Image { get; set; }
        [Display(Name = "Searchable Keyword")]
        public string KeyWord { get; set; }
        [Display(Name = "Product Code")]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Product Expire Date")]
        public DateTime ExpireDate { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Other Note")]
        public string Meta { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [Display(Name = "Product Category")]
        public string ProductCategoryID { get; set; }
        public ProductCategory ProductCategory { get; set; }
        [Required]
        [Display(Name = "Product Supplier")]
        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        [Required]
        [Display(Name = "Product Brand")]
        public string BrandId { get; set; }
        public Brand Brand { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}