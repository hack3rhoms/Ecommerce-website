using E_project.Data;
using E_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_project.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public AdminController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> WelcomeAdmin()
        {
            if (User.IsInRole("Admin")) 
            {
                ViewBag.Layout = "_AdminLayout";
            }
            else
            {
                ViewBag.Layout = "_Layout";
            }
            return View();
        }

        // عرض نموذج إضافة فئة
        public async Task<IActionResult> AddCategory()
        {
            // جلب القائمة من قاعدة البيانات
            var categories = await _appDbContext.Categories.ToListAsync();

            // تمرير القائمة والعنصر الجديد إلى العرض
            ViewBag.CategoriesList = categories; // القائمة
            return View(new Categories()); // العنصر الجديد
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(Categories category)
        {
            // إضافة الفئة الجديدة إلى قاعدة البيانات
            _appDbContext.Categories.Add(category);
            await _appDbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Category added successfully!";

            return RedirectToAction(nameof(AddCategory)); // إعادة التوجيه إلى نفس الصفحة
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var category = await _appDbContext.Categories.FindAsync(categoryId);

            if (category != null)
            {
                _appDbContext.Categories.Remove(category);
                await _appDbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(AddCategory)); // إعادة التوجيه إلى نفس الصفحة
        }
        

        //Add Sub Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubCategory(string name, int categoryId)
        {
            
            var subCategory = new SubCategory
            {
                Name = name,
                CategoryId = categoryId
            };

            _appDbContext.SubCategories.Add(subCategory);
            await _appDbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Sub Category added successfully!";

            return RedirectToAction("SubCategory");
        }
        // View Sub Category
        public async Task<IActionResult> SubCategory()
        {
            var categories = await _appDbContext.Categories.ToListAsync();
            ViewBag.SubCategories = await _appDbContext.SubCategories.Include(s => s.Category).ToListAsync();
            return View(categories);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSubCategory(int subCategoryId)
        {
            var subCategory = await _appDbContext.SubCategories.FindAsync(subCategoryId);

            if (subCategory != null)
            {
                _appDbContext.SubCategories.Remove(subCategory);
                await _appDbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(SubCategory)); 
        }

        


    }
}
