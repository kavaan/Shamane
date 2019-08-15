using Microsoft.EntityFrameworkCore;
using Shamane.DataAccess.UnitOfWorks;
using Shamane.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.DataAccess.MSSQL.Context
{
    public class ApplicationDbContext : DbContext, IAuthenticationUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<User> Users { set; get; }
        public virtual DbSet<Role> Roles { set; get; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }
        public virtual DbSet<Center> Centers { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<CenterProduct> CenterProducts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // it should be placed here, otherwise it will rewrite the following settings!
            base.OnModelCreating(builder);
            // Custom application mappings
            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.Username).HasMaxLength(450).IsRequired();
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.SerialNumber).HasMaxLength(450);
            });
            builder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(450).IsRequired();
                entity.HasIndex(e => e.Name).IsUnique();
            });
            builder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.RoleId);
                entity.Property(e => e.UserId);
                entity.Property(e => e.RoleId);
                entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasForeignKey(d => d.RoleId);
                entity.HasOne(d => d.User).WithMany(p => p.UserRoles).HasForeignKey(d => d.UserId);
            });
            builder.Entity<UserToken>(entity =>
            {
                entity.HasOne(ut => ut.User)
                      .WithMany(u => u.UserTokens)
                      .HasForeignKey(ut => ut.UserId);

                entity.Property(ut => ut.RefreshTokenIdHash).HasMaxLength(450).IsRequired();
                entity.Property(ut => ut.RefreshTokenIdHashSource).HasMaxLength(450);
            });
            builder.Entity<Center>(entity =>
            {
                entity.HasQueryFilter(x => !x.IsDeleted);
            });
            builder.Entity<Province>(entity =>
            {
                entity.HasQueryFilter(x => !x.IsDeleted);
            });
            builder.Entity<City>(entity =>
            {
                entity.HasQueryFilter(x => !x.IsDeleted);
            });
            builder.Entity<Product>(entity =>
            {
                entity.HasQueryFilter(x => !x.IsDeleted);
            });
            builder.Entity<CenterProduct>(entity =>
            {
                entity.HasQueryFilter(x => !x.IsDeleted);
            });
            builder.Entity<Order>(entity =>
            {
                entity.HasQueryFilter(x => !x.IsDeleted);
            });
            builder.Entity<OrderDetail>(entity =>
            {
                entity.HasQueryFilter(x => !x.IsDeleted);
            });
        }
    }
}
