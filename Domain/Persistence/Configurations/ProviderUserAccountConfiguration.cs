using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class ProviderUserAccountConfiguration : IEntityTypeConfiguration<ProviderUserAccount>
    {
        public void Configure(EntityTypeBuilder<ProviderUserAccount> builder)
        {
            builder.HasKey(u => u.UserName);

            builder.Property(u => u.UserName).HasColumnName("user_name").HasMaxLength(50);

            builder.Property(u => u.ProviderName).HasColumnName("provider_name").HasMaxLength(50);

            builder.Property(u => u.FullName).HasColumnName("full_name").HasMaxLength(100);

            builder.Property(u => u.IsAdmin).HasColumnName("is_admin").HasDefaultValue(false);

            builder.Property(u => u.Created).HasColumnName("created");

            //builder.Property(u => u.NativeUserName).HasColumnName("native_user_name").HasMaxLength(50);

            //builder.HasOne<NativeUserAccount>()
            //    .WithMany()
            //    .HasForeignKey(u => u.NativeUserName)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);  //OnDelete is still experimental
        }
    }
}
