﻿// <auto-generated />
using System;
using DalLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DalLibrary.Migrations
{
    [DbContext(typeof(AutoMarketContext))]
    [Migration("20220111095341_AFId2")]
    partial class AFId2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("DalLibrary.Models.Advert", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("BodyStyleId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("body_style_id");

                    b.Property<string>("CountryId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("country_id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("varchar(3000)")
                        .HasColumnName("description");

                    b.Property<string>("Drivetrain")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("drivetrain");

                    b.Property<int>("EngineCap")
                        .HasColumnType("int")
                        .HasColumnName("engine_cap");

                    b.Property<string>("Fuel")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("fuel");

                    b.Property<string>("GearboxType")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("gearbox_type");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int")
                        .HasColumnName("horse_power");

                    b.Property<int>("Km")
                        .HasColumnType("int")
                        .HasColumnName("km");

                    b.Property<string>("ModelId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("model_id");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<ulong>("Registered")
                        .HasColumnType("bit(1)")
                        .HasColumnName("registered");

                    b.Property<ulong>("ServiceDocs")
                        .HasColumnType("bit(1)")
                        .HasColumnName("service_docs");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("title");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.Property<string>("Vin")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("vin");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "BodyStyleId" }, "FK5hkqc8fc6ms7rwflvrn19dfhx");

                    b.HasIndex(new[] { "CountryId" }, "FK8dvdoawhjaf882jxx4o9ab4a8");

                    b.HasIndex(new[] { "ModelId" }, "FK9tatnvtavtuucjl0hkd7bnff1");

                    b.HasIndex(new[] { "UserId" }, "FKjds5rnsjbg4gr45pmn8bgd7dj");

                    b.ToTable("advert");
                });

            modelBuilder.Entity("DalLibrary.Models.AdvertFeature", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("AdvertId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("advert_id");

                    b.Property<string>("FeatureId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("feature_id");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "FeatureId" }, "FK9syg4onaa4l5ms94chv3efy4s");

                    b.HasIndex(new[] { "AdvertId" }, "FKi0w3bxv0f8v8j4ooicsrhjchp");

                    b.ToTable("advert_features");
                });

            modelBuilder.Entity("DalLibrary.Models.BodyStyle", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("body_style");
                });

            modelBuilder.Entity("DalLibrary.Models.Brand", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("brand");
                });

            modelBuilder.Entity("DalLibrary.Models.Comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<int?>("AdvertId")
                        .HasColumnType("int")
                        .HasColumnName("advert_id");

                    b.Property<string>("Comment1")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("comment");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AdvertId" }, "FK3uy78yort0pira8rwup9oeibt");

                    b.HasIndex(new[] { "UserId" }, "FK8kcum44fvpupyw6f5baccx25c");

                    b.ToTable("comment");
                });

            modelBuilder.Entity("DalLibrary.Models.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("country");
                });

            modelBuilder.Entity("DalLibrary.Models.Feature", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("feature");
                });

            modelBuilder.Entity("DalLibrary.Models.Image", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("AdvertId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("advert_id");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("MediumBlob")
                        .HasColumnName("imagedata");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AdvertId" }, "FKpr3xbu7a7bx3osujvrw4yfj6l");

                    b.ToTable("images");
                });

            modelBuilder.Entity("DalLibrary.Models.Model", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("BrandId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("brand_id");

                    b.Property<int>("FinalYear")
                        .HasColumnType("int")
                        .HasColumnName("final_year");

                    b.Property<string>("Generation")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("generation");

                    b.Property<int>("LaunchYear")
                        .HasColumnType("int")
                        .HasColumnName("launch_year");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "BrandId" }, "FKhbgv4j3vpt308sepyq9q79mhu");

                    b.ToTable("model");
                });

            modelBuilder.Entity("DalLibrary.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<ulong>("Active")
                        .HasColumnType("bit(1)")
                        .HasColumnName("active");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("birthdate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("last_name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Roles")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("roles");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
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
                    b.HasOne("DalLibrary.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DalLibrary.Models.User", null)
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

                    b.HasOne("DalLibrary.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DalLibrary.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
