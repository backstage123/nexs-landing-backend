using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class NativeUserAccountConfiguration : IEntityTypeConfiguration<NativeUserAccount>
    {
        public void Configure(EntityTypeBuilder<NativeUserAccount> builder)
        {
            builder.HasKey(u => u.UserName);
            
            builder.Property(u => u.UserName).HasColumnName("user_name").HasMaxLength(50);

            builder.Property(u => u.FullName).HasColumnName("full_name").HasMaxLength(100);

            builder.Property(u => u.Designation).HasColumnName("designation").HasMaxLength(100);

            builder.Property(u => u.IsAdmin).HasColumnName("is_admin");

            builder.Property(u => u.Created).HasColumnName("created");
        }
    }
}
