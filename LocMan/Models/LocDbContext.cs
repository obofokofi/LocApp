using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace LocMan.Models
{
    public partial class LocDbContext : DbContext
    {
        public LocDbContext()
        {
        }
        public LocDbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }
        public LocDbContext(DbContextOptions<LocDbContext> options): base(options)
        {
        }

        //public LocDbContext(DbContextOptions options) : base(options)
        //{
        //}

        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=OBOFO;Database=LocDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.DistrictId)
                    .HasName("PK3")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.DistrictCreatedOn).HasColumnType("date");

                entity.Property(e => e.DistrictDigitalAddress).HasMaxLength(25);

                entity.Property(e => e.DistrictIncorporatedOn).HasColumnType("date");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.DistrictUpdatedOn).HasColumnType("date");

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.HasOne(d => d.DistrictCreatedByNavigation)
                    .WithMany(p => p.DistrictDistrictCreatedByNavigation)
                    .HasForeignKey(d => d.DistrictCreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefUserInfo4");

                entity.HasOne(d => d.DistrictUpdatedByNavigation)
                    .WithMany(p => p.DistrictDistrictUpdatedByNavigation)
                    .HasForeignKey(d => d.DistrictUpdatedBy)
                    .HasConstraintName("RefUserInfo6");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.District)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("RefRegion1");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionId)
                    .HasName("PK2")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.RegionCreatedOn).HasColumnType("date");

                entity.Property(e => e.RegionDigitalAddress).HasMaxLength(25);

                entity.Property(e => e.RegionIncorporatedOn).HasColumnType("date");

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.RegionUpdatedOn).HasColumnType("date");

                entity.HasOne(d => d.RegionCreatedByNavigation)
                    .WithMany(p => p.RegionRegionCreatedByNavigation)
                    .HasForeignKey(d => d.RegionCreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefUserInfo5");

                entity.HasOne(d => d.RegionUpdatedByNavigation)
                    .WithMany(p => p.RegionRegionUpdatedByNavigation)
                    .HasForeignKey(d => d.RegionUpdatedBy)
                    .HasConstraintName("RefUserInfo7");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserInfoId)
                    .HasName("PK4")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.UserInfoId).HasColumnName("UserInfoID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("date");

                entity.Property(e => e.UserPass).IsRequired();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.InverseUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("RefUserInfo3");
            });
        }
    }
}
