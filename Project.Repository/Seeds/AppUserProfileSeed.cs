using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Models;

namespace Project.Repository.Seeds
{
    internal class AppUserProfileSeed : IEntityTypeConfiguration<AppUserProfile>
    {
        public void Configure(EntityTypeBuilder<AppUserProfile> builder)
        {
            builder.HasData
                (
                new AppUserProfile { Id = 1, FirstName = "Oğuzhan", LastName = "Kutucu", AppUserId = 1 },
                new AppUserProfile { Id = 2, FirstName = "Kaan", LastName = "Kutucu", AppUserId = 2 }
                );
        }
    }
}
