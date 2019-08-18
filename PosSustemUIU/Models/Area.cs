using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PosSustemUIU.Models {
    public class Area {
        [Key]
        public string Id { get; set; }

        [Required]
        [Display (Name = "Area Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string TextCode { get; set; }
        public string NumericCode { get; set; }
        public bool IsActive { get; set; }
        public string Meta { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public ICollection<Customer> Customers { get; set; }

    }
}