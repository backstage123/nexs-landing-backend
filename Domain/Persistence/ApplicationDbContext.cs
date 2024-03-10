using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseNpgsql("Host=localhost; Database=nexs_landing; Port=5433; Username=postgres; Password=1234");

            System.Diagnostics.Debug.WriteLine(_configuration.GetConnectionString("development"));
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("development"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //modelBuilder.Entity<NativeUserAccount>().ToTable("native_user_account");

            modelBuilder.Entity<ProviderUserAccount>().ToTable("provider_user_account");

            modelBuilder.Entity<Notice>().ToTable("notice");
        }

        //public DbSet<NativeUserAccount>? NativeUserAccounts { get; set; }

        public DbSet<ProviderUserAccount>? ProviderUserAccounts { get; set; }

        public DbSet<Notice>? Notice { get; set; }
    }
}
