﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence;

#nullable disable

namespace ToDoManager.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240704092724_AddUserTable")]
    partial class AddUserTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)")
                        .HasColumnName("sername");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("category_title");

                    b.HasKey("Id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c3d4c014-49b6-410c-bc78-1d54a9991870"),
                            Description = "Здесь как правило нет каких то значимых дел",
                            Title = "Досуг"
                        });
                });

            modelBuilder.Entity("Entities.TaskItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("task_id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("description");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiration_date");

                    b.Property<byte>("PriorityTask")
                        .HasColumnType("smallint")
                        .HasColumnName("priority");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("task_title");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("tasks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("60abbca8-664d-4b20-b5de-024705497d4a"),
                            CategoryId = new Guid("c3d4c014-49b6-410c-bc78-1d54a9991870"),
                            CreatedAt = new DateTime(2024, 7, 4, 9, 27, 22, 148, DateTimeKind.Utc).AddTicks(3051),
                            Description = "Пить кофе весело, пить кофе хорошо)",
                            ExpirationDate = new DateTime(2024, 7, 6, 23, 34, 42, 361, DateTimeKind.Utc),
                            PriorityTask = (byte)1,
                            Title = "Попить кофе",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TaskItemUser", b =>
                {
                    b.Property<Guid>("TasksId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("TasksId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskItemUser");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Entities.Category", null)
                        .WithMany("Users")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Entities.TaskItem", b =>
                {
                    b.HasOne("Entities.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskItemUser", b =>
                {
                    b.HasOne("Entities.TaskItem", null)
                        .WithMany()
                        .HasForeignKey("TasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Navigation("Tasks");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}