using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Repository.Configuraytions
{
    internal class AppUserProfileConfiguration : IEntityTypeConfiguration<AppUserProfileConfiguration>
    {
        public void Configure(EntityTypeBuilder<AppUserProfileConfiguration> builder)
        {
           
        }
    }
}
