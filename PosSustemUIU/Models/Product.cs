using System.ComponentModel.DataAnnotations;

namespace PosSustemUIU.Models
{
    public class Product
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Category Name Required")]
        [Display(Name = "Category name")]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string KeyWord { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public string Meta { get; set; }
        public bool IsDeleted { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}