using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Models;

namespace Project.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
               new Product { Id = 1, CategoryId = 1, Name = "Kalem 1", Price = 100, Stock = 20 },
               new Product { Id = 2, CategoryId = 1, Name = "Kalem 2", Price = 200, Stock = 10 },
               new Product { Id = 3, CategoryId = 2, Name = "Kitap 1", Price = 500, Stock = 5 },
               new Product { Id = 4, CategoryId = 3, Name = "Defter", Price = 25, Stock = 12 }

           );
        }
    }
}
