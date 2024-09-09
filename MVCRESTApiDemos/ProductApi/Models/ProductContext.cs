using Microsoft.EntityFrameworkCore;

namespace ProductApi.Models
{
    public class ProductContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=localhost;initial catalog=jeanstation;integrated security=true;trustservercertificate=true;");
        }
    }
}
