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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.1.20;Database=DoYouNowThese;User Id=sa;Password = Fibanez756.;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ResetKeyCode).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(100);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<InformationContent>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.InformationContent)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Informati__Autho__5FB337D6");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.InformationContent)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Informati__Categ__5EBF139D");
            });

            modelBuilder.Entity<InformationReadLog>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.InformationReadLog)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("FK__Informati__AppUs__628FA481");

                entity.HasOne(d => d.InformationContent)
                    .WithMany(p => p.InformationReadLog)
                    .HasForeignKey(d => d.InformationContentId)
                    .HasConstraintName("FK__Informati__Infor__6383C8BA");
            });
        }
    }
}
