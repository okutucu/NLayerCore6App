using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Models;

namespace Project.Repository.Seeds
{
    internal class AppUserSeed : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData
                (
                new AppUser { Id = 1, UserName = "Oguz", Password = "1234" },
                new AppUser { Id = 2, UserName = "Kaan", Password = "3211" }
                );
        }
    }
}
