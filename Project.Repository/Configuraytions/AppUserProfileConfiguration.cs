using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Models;

namespace Project.Repository.Configuraytions
{
    internal class AppUserProfileConfiguration : IEntityTypeConfiguration<AppUserProfile>
    {
        public void Configure(EntityTypeBuilder<AppUserProfile> builder)
        {
            builder.HasOne(x => x.AppUser).WithOne(x => x.AppUserProfile).HasForeignKey<AppUserProfile>(x => x.Id);
        }
    }
}
