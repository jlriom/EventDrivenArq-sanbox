using Microsoft.EntityFrameworkCore;
using Sandbox.Shared.Data.Blob.Core;

namespace Sandbox.Shared.Data.Blob.EntityFrameworkCore
{
    public partial class BlobDocumentDbContext : DbContext
    {

        public BlobDocumentDbContext(DbContextOptions<BlobDocumentDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document", "blob");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Content)
                    .IsRequired();
            });
        }
    }
}
