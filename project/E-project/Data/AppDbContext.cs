using Microsoft.EntityFrameworkCore;
using E_project.Models;


namespace E_project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
