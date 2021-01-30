using Microsoft.EntityFrameworkCore;
using Sandbox.Shared.Data.System.Core;

namespace Sandbox.Shared.Data.System.EntityFrameworkCore
{
    public partial class SystemDbContext : DbContext
    {

        public SystemDbContext(DbContextOptions<SystemDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Settings> SysConfig { get; set; }
        public virtual DbSet<LogEntry> LogEntry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.ToTable("Settings", "system");
                entity.HasKey(e => e.Key);

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.Module).HasMaxLength(200);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<LogEntry>(entity =>
            {
                entity.ToTable("Logs", "system");
                entity.HasKey(e => e.Id);
            });
        }
    }
}
