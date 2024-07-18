﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using netcore_devsecops.Database;

#nullable disable

namespace netcore_devsecops.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240718020035_addPermission")]
    partial class addPermission
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("netcore_devsecops.Models.Permission", b =>
                {
                    b.Property<Guid>("IdPermission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPermission");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            IdPermission = new Guid("f87ac10b-67cc-4372-a567-0e02b2c3d479"),
                            Name = "admin"
                        },
                        new
                        {
                            IdPermission = new Guid("f49ac10b-68cc-4372-a567-0e02b2c3d479"),
                            Name = "finance"
                        });
                });

            modelBuilder.Entity("netcore_devsecops.Models.Role", b =>
                {
                    b.Property<Guid>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRole");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            IdRole = new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479"),
                            Name = "ADMIN"
                        },
                        new
                        {
                            IdRole = new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479"),
                            Name = "FINANCER"
                        });
                });

            modelBuilder.Entity("netcore_devsecops.Models.RolePermission", b =>
                {
                    b.Property<Guid>("IdRole")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPermission")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAccessed")
                        .HasColumnType("bit");

                    b.HasKey("IdRole", "IdPermission");

                    b.HasIndex("IdPermission");

                    b.ToTable("RolePermissions");

                    b.HasData(
                        new
                        {
                            IdRole = new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479"),
                            IdPermission = new Guid("f87ac10b-67cc-4372-a567-0e02b2c3d479"),
                            IsAccessed = true
                        },
                        new
                        {
                            IdRole = new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479"),
                            IdPermission = new Guid("f49ac10b-68cc-4372-a567-0e02b2c3d479"),
                            IsAccessed = true
                        },
                        new
                        {
                            IdRole = new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479"),
                            IdPermission = new Guid("f87ac10b-67cc-4372-a567-0e02b2c3d479"),
                            IsAccessed = true
                        },
                        new
                        {
                            IdRole = new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479"),
                            IdPermission = new Guid("f49ac10b-68cc-4372-a567-0e02b2c3d479"),
                            IsAccessed = true
                        });
                });

            modelBuilder.Entity("netcore_devsecops.Models.User", b =>
                {
                    b.Property<Guid>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdRole")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoleIdRole")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdUser");

                    b.HasIndex("RoleIdRole");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            IdUser = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
                            Email = "letuyenkhtn212@gmail.com",
                            IdRole = new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479"),
                            Password = "1234"
                        },
                        new
                        {
                            IdUser = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d487"),
                            Email = "test@gmail.com",
                            IdRole = new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479"),
                            Password = "1234"
                        });
                });

            modelBuilder.Entity("netcore_devsecops.Models.RolePermission", b =>
                {
                    b.HasOne("netcore_devsecops.Models.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("IdPermission")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("netcore_devsecops.Models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("netcore_devsecops.Models.User", b =>
                {
                    b.HasOne("netcore_devsecops.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleIdRole");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("netcore_devsecops.Models.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
