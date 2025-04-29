using System.ComponentModel.DataAnnotations;

namespace E_project.Models
{
    public class Categories
    {
        [Key]
        public int categoryId { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Slug is required.")]
        [Display(Name = "Slug")]
        public string Slug { get; set; } // <<< أضفنا هذا السطر

        public ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
    }
}
