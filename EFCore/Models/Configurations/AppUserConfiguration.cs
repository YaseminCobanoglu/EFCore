﻿using EFCore.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Models.Configurations
{
    public class AppUserConfiguration:BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
            builder.HasOne(x=>x.Profile).WithOne(x=>x.AppUser).HasForeignKey<AppUserProfile>(x=>x.ID);
        }
    }
}
