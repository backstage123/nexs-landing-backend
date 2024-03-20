using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    internal class NoticeConfiguration : IEntityTypeConfiguration<Notice>
    {
        public void Configure(EntityTypeBuilder<Notice> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id).HasColumnName("id");

            builder.Property(n => n.Id).ValueGeneratedOnAdd();  //auto increament

            builder.Property(n => n.Title).HasColumnName("title").HasMaxLength(100);

            builder.HasIndex(n => n.Id).IsUnique();

            builder.Property(n => n.Content).HasColumnName("content").HasMaxLength(int.MaxValue);

            builder.Property(n => n.Created).HasColumnName("created")/*.HasColumnType("date")*/;

            builder.Property(n => n.Updated).HasColumnName("updated")/*.HasColumnType("date")*/;            

            builder.HasOne<ProviderUserAccount>()
                .WithMany()
                .HasForeignKey(u => u.AuthorName)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(n => n.AuthorName).HasColumnName("author_name");
        }
    }
}
