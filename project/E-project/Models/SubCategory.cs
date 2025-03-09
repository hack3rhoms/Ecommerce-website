using System.ComponentModel.DataAnnotations;

namespace E_project.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Categories Category { get; set; }
    }
}
