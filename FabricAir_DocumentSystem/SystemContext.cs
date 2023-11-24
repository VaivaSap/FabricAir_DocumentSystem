using FabricAir_DocumentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FabricAir_DocumentSystem
{
    public class SystemContext : DbContext
    {
        protected readonly IConfiguration Configuration;


        public SystemContext(DbContextOptions<SystemContext> options, IConfiguration configuration)
      : base(options)
        { Configuration = configuration;

        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Files> Files { get; set; }
        public DbSet<FileTypes> FileTypes { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<AccessScope> AcessScope { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<Files>();
        //    builder.Entity<FileTypes>();
        //    builder.Entity<Users>();
        //    builder.Entity<UserRoles>();  
        //    builder.Entity<AccessScope>();



        }

    }

