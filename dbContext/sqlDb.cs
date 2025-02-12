using AspCoreWebApp2309D.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreWebApp2309D.dbContext
{
    public class sqlDb : DbContext
    {
        public sqlDb(DbContextOptions<sqlDb>options) : base(options) 
        {

        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Products> tblProducts { get; set; }
        public DbSet<Users> tblUsers { get; set; }
        public DbSet<Category> tblCategories { get; set; }
    }
}
