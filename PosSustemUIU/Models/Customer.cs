using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PosSustemUIU.Models {
    public class Customer {
        [Key]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string OtherContact { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Area Area { get; set; }
        public bool IsActive { get; set; }
        public string Meta { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
    }
}