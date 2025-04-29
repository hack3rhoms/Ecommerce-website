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

        public ICollection<Mobile> Mobiles { get; set; } = new List<Mobile>();
        public ICollection<Laptop> Laptops { get; set; } = new List<Laptop>();

    }
}
