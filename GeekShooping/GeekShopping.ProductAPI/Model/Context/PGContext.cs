using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class PGContext : DbContext
    {
        public PGContext() { }
        public PGContext(DbContextOptions options)  : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product 
            {
                Id = 2,
                Name = "Name",
                Price = new decimal(69.9),
                Description = "Descricao Teste",
                ImageUrl = "",
                CategoryName = "T-Shirt"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Name 3",
                Price = new decimal(6.4),
                Description = "Descricao Teste 02",
                ImageUrl = "",
                CategoryName = "T-Shirt"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Name 3",
                Price = new decimal(41.9),
                Description = "Descricao Teste 4",
                ImageUrl = "",
                CategoryName = "T-Shirt"
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
