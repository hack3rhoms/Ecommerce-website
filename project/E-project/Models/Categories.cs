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

        // العلاقة: Category يمكن أن يحتوي على عدة SubCategories
        public ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();

    }
}
