using System;
using System.ComponentModel.DataAnnotations;

namespace PosSustemUIU.Models {
    public class Product {
        [Key]
        public string Id { get; set; }

        [Required (ErrorMessage = "Category Name Required")]
        [Display (Name = "Category Name")]
        [MaxLength (50)]
        public string Name { get; set; }
        public double Price { get; set; }
        public double Vat { get; set; }
        public double Unit { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string KeyWord { get; set; }
        public string Code { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
        public string Meta { get; set; }
        public bool IsDeleted { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public Supplier Supplier { get; set; }
        public Brand Brand { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}