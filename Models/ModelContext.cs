using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace livestockProject.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Importedmeal> Importedmeals { get; set; } = null!;
        public virtual DbSet<SysModuel> SysModuels { get; set; } = null!;
        public virtual DbSet<SystemCountry> SystemCountries { get; set; } = null!;
        public virtual DbSet<SystemLivestockType> SystemLivestockTypes { get; set; } = null!;
        public virtual DbSet<SystemMenu> SystemMenus { get; set; } = null!;
        public virtual DbSet<SystemUser> SystemUsers { get; set; } = null!;
        public virtual DbSet<SystemUserGroup> SystemUserGroups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.25)(PORT=1521))(CONNECT_DATA=(SID=worcl)));User Id=livestock;Password=livestock;Persist Security Info=True;Connection Lifetime=100000;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("LIVESTOCK");

            modelBuilder.Entity<Importedmeal>(entity =>
            {
                entity.ToTable("IMPORTEDMEAL");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Count)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COUNT");

                entity.Property(e => e.Grossweight)
                    .HasColumnType("FLOAT")
                    .HasColumnName("GROSSWEIGHT");

                entity.Property(e => e.Livestocktype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LIVESTOCKTYPE");

                entity.Property(e => e.MealName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MEAL_NAME");

                entity.Property(e => e.Netweight)
                    .HasColumnType("FLOAT")
                    .HasColumnName("NETWEIGHT");

                entity.Property(e => e.Origincountry)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ORIGINCOUNTRY");

                entity.Property(e => e.Shipmentarrivaldate)
                    .HasColumnType("DATE")
                    .HasColumnName("SHIPMENTARRIVALDATE");

                entity.Property(e => e.Shippingdate)
                    .HasColumnType("DATE")
                    .HasColumnName("SHIPPINGDATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<SysModuel>(entity =>
            {
                entity.ToTable("SYS_MODUEL");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID");

                entity.Property(e => e.DescAr)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("DESC_AR");

                entity.Property(e => e.DescEn)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("DESC_EN");

                entity.Property(e => e.IsActive)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IS_ACTIVE");

                entity.Property(e => e.Moduleicon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODULEICON");

                entity.Property(e => e.Moduleiconen)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("MODULEICONEN");
            });

            modelBuilder.Entity<SystemCountry>(entity =>
            {
                entity.ToTable("SYSTEM_COUNTRY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.NameArabic)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME_ARABIC");
            });

            modelBuilder.Entity<SystemLivestockType>(entity =>
            {
                entity.ToTable("SYSTEM_LIVESTOCK_TYPE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.NameArabic)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME_ARABIC");
            });

            modelBuilder.Entity<SystemMenu>(entity =>
            {
                entity.ToTable("SYSTEM_MENU");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.Createduser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEDUSER");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_UPDATE_DATE");

                entity.Property(e => e.LastUpdatedUser)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_USER");

                entity.Property(e => e.MenuController)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MENU_CONTROLLER");

                entity.Property(e => e.MenuFlag)
                    .HasPrecision(1)
                    .HasColumnName("MENU_FLAG");

                entity.Property(e => e.MenuView)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MENU_VIEW");

                entity.Property(e => e.MenunameAr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MENUNAME_AR");

                entity.Property(e => e.MenunameEn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MENUNAME_EN");

                entity.Property(e => e.Menuorder)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MENUORDER");

                entity.Property(e => e.ModuleId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MODULE_ID");

                entity.Property(e => e.PerantId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PERANT_ID");

                entity.Property(e => e.SystemFunction)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("SYSTEM_FUNCTION");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.SystemMenus)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("SYS_MENU_FK");
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.ToTable("SYSTEM_USERS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID");

                entity.Property(e => e.IsActive)
                    .HasPrecision(1)
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("1 \n");

                entity.Property(e => e.LastChangePassword)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_CHANGE_PASSWORD");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_LOGIN_DATE");

                entity.Property(e => e.NameArabic)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME_ARABIC");

                entity.Property(e => e.NameEnglish)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME_ENGLISH");

                entity.Property(e => e.Upassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPASSWORD");

                entity.Property(e => e.UserGroupId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_GROUP_ID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.SystemUsers)
                    .HasForeignKey(d => d.UserGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_USER_FK");
            });

            modelBuilder.Entity<SystemUserGroup>(entity =>
            {
                entity.HasKey(e => e.UserGroupId)
                    .HasName("SYSTEM_USER_GROUP_PK");

                entity.ToTable("SYSTEM_USER_GROUP");

                entity.Property(e => e.UserGroupId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_GROUP_ID");

                entity.Property(e => e.MenuId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MENU_ID");

                entity.Property(e => e.NameAr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME_AR");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME_EN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
