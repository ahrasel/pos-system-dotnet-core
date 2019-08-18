using System;
using System.ComponentModel.DataAnnotations;

namespace PosSustemUIU.Models {
    public class TransectionType {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string GroupName { get; set; }
        public bool IsActive { get; set; }
        public string Meta { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}