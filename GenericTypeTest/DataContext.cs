using GenericTypeTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericTypeTest
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions opt):base(opt)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }    
    }
}
