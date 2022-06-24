using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Models;

namespace Project.Repository.Configurations
{
    internal class AppUserProfileConfiguration : IEntityTypeConfiguration<AppUserProfile>
    {
        public void Configure(EntityTypeBuilder<AppUserProfile> builder)
        {
            builder.HasOne(x => x.AppUser).WithOne(x => x.AppUserProfile).HasForeignKey<AppUserProfile>(x => x.Id);
        }
    }
}
