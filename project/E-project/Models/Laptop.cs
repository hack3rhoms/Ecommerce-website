using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_project.Models
{
    public class Laptop
    {
        [Key]
        public int LaptopId { get; set; }

        [Required(ErrorMessage = "Laptop name is required.")]
        [Display(Name = "Laptop Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Images")]
        public List<byte[]> Images { get; set; } = new List<byte[]>();

        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Processor")]
        public string Processor { get; set; }

        [Display(Name = "RAM")]
        public string RAM { get; set; }

        [Display(Name = "Storage")]
        public string Storage { get; set; }

        [Display(Name = "Screen Size (inches)")]
        public double ScreenSize { get; set; }

        [Display(Name = "Graphics Card")]
        public string GraphicsCard { get; set; }

        [Display(Name = "Operating System")]
        public string OperatingSystem { get; set; }

        [Display(Name = "Year of Manufacture")]
        public int ManufactureYear { get; set; }

        // العلاقة مع SubCategory
        [Required]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
