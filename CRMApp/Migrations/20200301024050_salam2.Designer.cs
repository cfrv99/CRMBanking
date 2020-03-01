﻿// <auto-generated />
using System;
using CRMApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRMApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200301024050_salam2")]
    partial class salam2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRMApp.Models.AnnouncementWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClaimId");

                    b.Property<string>("Description");

                    b.Property<decimal>("MinSalary");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ClaimId");

                    b.ToTable("AnnouncementWorks");
                });

            modelBuilder.Entity("CRMApp.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<decimal>("Amount");

                    b.Property<int?>("CardId");

                    b.Property<int?>("ClaimId");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<bool>("PermissionCompany");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("Role");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Signature");

                    b.Property<int?>("StaffContractId");

                    b.Property<string>("Tel");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("ClaimId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CRMApp.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("CRMApp.Models.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnnouncmentWorkId");

                    b.Property<string>("AppUserId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsAccepted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AnnouncmentWorkId");

                    b.HasIndex("AppUserId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("CRMApp.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("AppUserId");

                    b.Property<DateTime>("Expire");

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("CRMApp.Models.Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("CRMApp.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("CreatorId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId")
                        .IsUnique()
                        .HasFilter("[CreatorId] IS NOT NULL");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("CRMApp.Models.CompanyContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agreements");

                    b.Property<decimal>("Amount");

                    b.Property<int?>("CompanyId");

                    b.Property<decimal>("MonthCount");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyContracts");
                });

            modelBuilder.Entity("CRMApp.Models.JobTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("AppUserId");

                    b.Property<int?>("ClaimId");

                    b.Property<int?>("CompanyId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DeadLine");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ClaimId");

                    b.HasIndex("CompanyId");

                    b.ToTable("JobTasks");
                });

            modelBuilder.Entity("CRMApp.Models.MonthlyAmount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("AppUserId");

                    b.Property<int?>("CompanyId");

                    b.Property<DateTime>("SalaryDate");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CompanyId");

                    b.ToTable("MonthlyAmounts");
                });

            modelBuilder.Entity("CRMApp.Models.MonthlySalary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("AppUserId");

                    b.Property<DateTime>("SalaryDate");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("MonthlySalaries");
                });

            modelBuilder.Entity("CRMApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CRMApp.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId");

                    b.Property<bool>("IsAccepted");

                    b.Property<string>("RequestDescription");

                    b.Property<string>("RequestTitle");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("CRMApp.Models.StaffContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agreement");

                    b.Property<string>("AppUserId");

                    b.Property<DateTime>("Expire");

                    b.Property<decimal>("MonthlySalary");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique()
                        .HasFilter("[AppUserId] IS NOT NULL");

                    b.ToTable("StaffContracts");
                });

            modelBuilder.Entity("CRMApp.Models.StaffRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ability");

                    b.Property<string>("About");

                    b.Property<string>("AppUserId");

                    b.Property<int>("CompanyId");

                    b.Property<decimal>("MinSalary");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CompanyId");

                    b.ToTable("StaffRequests");
                });

            modelBuilder.Entity("CRMApp.Models.UserContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agreement");

                    b.Property<decimal>("Amount");

                    b.Property<string>("AppUserId");

                    b.Property<decimal>("MonthCount");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("UserContracts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CRMApp.Models.AnnouncementWork", b =>
                {
                    b.HasOne("CRMApp.Models.Claim", "Claim")
                        .WithMany()
                        .HasForeignKey("ClaimId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRMApp.Models.AppUser", b =>
                {
                    b.HasOne("CRMApp.Models.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId");

                    b.HasOne("CRMApp.Models.Claim", "Claim")
                        .WithMany()
                        .HasForeignKey("ClaimId");

                    b.HasOne("CRMApp.Models.Company", "Company")
                        .WithMany("AppUsers")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("CRMApp.Models.Bid", b =>
                {
                    b.HasOne("CRMApp.Models.AnnouncementWork", "AnnouncmentWork")
                        .WithMany()
                        .HasForeignKey("AnnouncmentWorkId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRMApp.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("CRMApp.Models.Card", b =>
                {
                    b.HasOne("CRMApp.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("CRMApp.Models.Claim", b =>
                {
                    b.HasOne("CRMApp.Models.Company", "Company")
                        .WithMany("Claims")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("CRMApp.Models.Company", b =>
                {
                    b.HasOne("CRMApp.Models.AppUser", "Creator")
                        .WithOne()
                        .HasForeignKey("CRMApp.Models.Company", "CreatorId");
                });

            modelBuilder.Entity("CRMApp.Models.CompanyContract", b =>
                {
                    b.HasOne("CRMApp.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("CRMApp.Models.JobTask", b =>
                {
                    b.HasOne("CRMApp.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("CRMApp.Models.Claim", "Claim")
                        .WithMany()
                        .HasForeignKey("ClaimId");

                    b.HasOne("CRMApp.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("CRMApp.Models.MonthlyAmount", b =>
                {
                    b.HasOne("CRMApp.Models.AppUser", "AppUser")
                        .WithMany("MonthlyAmounts")
                        .HasForeignKey("AppUserId");

                    b.HasOne("CRMApp.Models.Company", "Company")
                        .WithMany("MonthlyAmounts")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("CRMApp.Models.MonthlySalary", b =>
                {
                    b.HasOne("CRMApp.Models.AppUser", "AppUser")
                        .WithMany("MonthlySalaries")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("CRMApp.Models.Product", b =>
                {
                    b.HasOne("CRMApp.Models.AppUser", "AppUser")
                        .WithMany("Products")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("CRMApp.Models.Request", b =>
                {
                    b.HasOne("CRMApp.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("CRMApp.Models.StaffContract", b =>
                {
                    b.HasOne("CRMApp.Models.AppUser", "AppUser")
                        .WithOne("StaffContract")
                        .HasForeignKey("CRMApp.Models.StaffContract", "AppUserId");
                });

            modelBuilder.Entity("CRMApp.Models.StaffRequest", b =>
                {
                    b.HasOne("CRMApp.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("CRMApp.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRMApp.Models.UserContract", b =>
                {
                    b.HasOne("CRMApp.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CRMApp.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CRMApp.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRMApp.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CRMApp.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
