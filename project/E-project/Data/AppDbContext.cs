using Microsoft.EntityFrameworkCore;
using E_project.Models;
using System.Reflection;


namespace E_project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<Laptop> Laptops { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // تحديد العلاقة بين Category و SubCategory
            modelBuilder.Entity<SubCategory>()
                .HasOne(s => s.Category) // SubCategory يحتوي على Category واحد
                .WithMany(c => c.SubCategories) // Category يمكن أن يحتوي على عدة SubCategories
                .HasForeignKey(s => s.CategoryId) // مفتاح الربط
                .OnDelete(DeleteBehavior.Cascade); // عند حذف Category، يتم حذف SubCategories التابعة له

            // تحديد العلاقة بين SubCategory و Mobile
            modelBuilder.Entity<Mobile>()
                .HasOne(m => m.SubCategory)
                .WithMany(s => s.Mobiles)
                .HasForeignKey(m => m.SubCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // تحديد العلاقة بين SubCategory و Laptop
            modelBuilder.Entity<Laptop>()
                .HasOne(l => l.SubCategory)
                .WithMany(s => s.Laptops)
                .HasForeignKey(l => l.SubCategoryId)
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);



        }

    }
}
