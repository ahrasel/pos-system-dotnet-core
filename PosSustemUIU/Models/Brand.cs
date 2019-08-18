using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PosSustemUIU.Models {
    public class Brand {
        [Key]
        public string Id { get; set; }

        [Required]
        [Display (Name = "Supplier Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public string Meta { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}