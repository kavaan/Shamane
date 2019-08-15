﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shamane.DataAccess.MSSQL.Context;

namespace Shamane.DataAccess.MSSQL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190814202437_AddUnitPriceToOrderDetial")]
    partial class AddUnitPriceToOrderDetial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shamane.Domain.Center", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("AttachmentImage");

                    b.Property<string>("BannerImage");

                    b.Property<int>("CenterType");

                    b.Property<Guid>("CityId");

                    b.Property<DateTime>("ContractEndDate");

                    b.Property<string>("ContractNumber");

                    b.Property<DateTime>("ContractStartDate");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedBy");

                    b.Property<string>("DeliveryComment");

                    b.Property<int>("DeliveryType");

                    b.Property<bool>("IsDeleted");

                    b.Property<long>("Lat");

                    b.Property<long>("Lng");

                    b.Property<string>("LogoImage");

                    b.Property<string>("Mail");

                    b.Property<int>("Priority");

                    b.Property<int>("Tax");

                    b.Property<string>("Tellphone");

                    b.Property<string>("Title");

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Centers");
                });

            modelBuilder.Entity("Shamane.Domain.CenterProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CenterId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<bool>("IsDeleted");

                    b.Property<long>("Price");

                    b.Property<Guid>("ProductId");

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.HasIndex("ProductId");

                    b.ToTable("CenterProducts");
                });

            modelBuilder.Entity("Shamane.Domain.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedBy");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<Guid>("ProvinceId");

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Shamane.Domain.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AcceptedBy");

                    b.Property<DateTime?>("AcceptedDateTime");

                    b.Property<string>("Address");

                    b.Property<Guid>("CenterId");

                    b.Property<Guid>("CompletedBy");

                    b.Property<DateTime?>("CompletedDateTime");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedBy");

                    b.Property<long?>("DeliveryPrice");

                    b.Property<string>("Description");

                    b.Property<long?>("Discount");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("OrderCode");

                    b.Property<int>("OrderDeliverType");

                    b.Property<int>("OrderStaus");

                    b.Property<DateTime>("RegisterdAt");

                    b.Property<string>("RejectReason");

                    b.Property<Guid>("RejectedBy");

                    b.Property<DateTime?>("RejectedDateTime");

                    b.Property<DateTime?>("SendToDelivertDateTime");

                    b.Property<bool>("TargetAddressIsUserProfileAddress");

                    b.Property<long?>("Tax");

                    b.Property<long?>("TotlaPrice");

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shamane.Domain.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CenterProductId");

                    b.Property<int>("Count");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedBy");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid?>("OrderId");

                    b.Property<long>("UnitPrice");

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CenterProductId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Shamane.Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<Guid?>("EspeciallyForCenterId");

                    b.Property<string>("Formula");

                    b.Property<string>("Image");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ParentId");

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("EspeciallyForCenterId");

                    b.HasIndex("ParentId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Shamane.Domain.Province", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedBy");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<Guid?>("UpdateBy");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("Shamane.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Shamane.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsActive");

                    b.Property<DateTimeOffset?>("LastLoggedIn");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(450);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Shamane.Domain.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Shamane.Domain.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("AccessTokenExpiresDateTime");

                    b.Property<string>("AccessTokenHash");

                    b.Property<DateTimeOffset>("RefreshTokenExpiresDateTime");

                    b.Property<string>("RefreshTokenIdHash")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("RefreshTokenIdHashSource")
                        .HasMaxLength(450);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Shamane.Domain.Center", b =>
                {
                    b.HasOne("Shamane.Domain.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shamane.Domain.CenterProduct", b =>
                {
                    b.HasOne("Shamane.Domain.Center", "Center")
                        .WithMany()
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shamane.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shamane.Domain.City", b =>
                {
                    b.HasOne("Shamane.Domain.Province", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shamane.Domain.Order", b =>
                {
                    b.HasOne("Shamane.Domain.Center", "Center")
                        .WithMany()
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shamane.Domain.OrderDetail", b =>
                {
                    b.HasOne("Shamane.Domain.CenterProduct", "CenterProduct")
                        .WithMany()
                        .HasForeignKey("CenterProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shamane.Domain.Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Shamane.Domain.Product", b =>
                {
                    b.HasOne("Shamane.Domain.Center", "EspeciallyForCenter")
                        .WithMany()
                        .HasForeignKey("EspeciallyForCenterId");

                    b.HasOne("Shamane.Domain.Product", "Parent")
                        .WithMany("Childs")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Shamane.Domain.UserRole", b =>
                {
                    b.HasOne("Shamane.Domain.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shamane.Domain.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shamane.Domain.UserToken", b =>
                {
                    b.HasOne("Shamane.Domain.User", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
