using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DoYouNowThese.DATA.Models
{
    public partial class DoYouNowTheseContext : DbContext
    {
        public DoYouNowTheseContext()
        {
        }

        public DoYouNowTheseContext(DbContextOptions<DoYouNowTheseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUser { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<InformationContent> InformationContent { get; set; }
        public virtual DbSet<InformationReadLog> InformationReadLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Scaffold-DbContext "Server=.;Database=DoYouNowThese;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
                optionsBuilder.UseSqlServer("Server=.;Database=DoYouNowThese;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ResetKeyCode).HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<InformationContent>(entity =>
            {
                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.LikeCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.InformationContent)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Informati__Autho__2E1BDC42");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.InformationContent)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Informati__Categ__2D27B809");
            });

            modelBuilder.Entity<InformationReadLog>(entity =>
            {
                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.InformationReadLog)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("FK__Informati__AppUs__34C8D9D1");

                entity.HasOne(d => d.InformationContent)
                    .WithMany(p => p.InformationReadLog)
                    .HasForeignKey(d => d.InformationContentId)
                    .HasConstraintName("FK__Informati__Infor__35BCFE0A");
            });
        }
    }
}
