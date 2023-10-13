using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace livestockProject.Models
{
    public partial class livestockContext : DbContext
    {
        public livestockContext()
        {
        }

        public livestockContext(DbContextOptions<livestockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Importedmeal> Importedmeals { get; set; } = null!;
        public virtual DbSet<SystemUser> SystemUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-OSQTMG0\\SQLEXPRESS;Database=livestock;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Importedmeal>(entity =>
            {
                entity.ToTable("Importedmeal");

                entity.Property(e => e.Count).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Grossweight).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Netweight).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Shipmentarrivaldate).HasColumnType("date");

                entity.Property(e => e.Shippingdate).HasColumnType("date");
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.Property(e => e.Groupid).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LastChangePassword).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.NameArabic).HasMaxLength(255);

                entity.Property(e => e.NameEnglish).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Username).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
