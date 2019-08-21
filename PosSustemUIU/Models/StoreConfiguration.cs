using System;
using System.ComponentModel.DataAnnotations;

namespace PosSustemUIU.Models
{
    public class StoreConfiguration
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sologan { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public string MainContact { get; set; }
        public string OtherContact { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Others")]
        public string Meta { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}