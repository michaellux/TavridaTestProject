using Microsoft.EntityFrameworkCore;

namespace TavridaTest.Models
{
    public class TavridaContext : DbContext
    {
        public TavridaContext(DbContextOptions<TavridaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyBranch> CompanyBranch { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql("newid()"); 
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.BinarySign).IsRequired().HasColumnType("bit");
            });

            modelBuilder.Entity<CompanyBranch>(entity =>
            {
                entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql("newid()");
                entity.HasOne(e => e.Company)
                .WithMany(e => e.CompanyBranches)
                .HasForeignKey(e => e.CompanyId);
            });
        }
    }
}
