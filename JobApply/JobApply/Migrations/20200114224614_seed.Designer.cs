﻿// <auto-generated />
using System;
using JobApply.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobApply.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200114224614_seed")]
    partial class seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobApply.Models.CompanyModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("ContactEmail")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<DateTime>("FoundationDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new { Id = 2551, City = "Washington", ContactEmail = "nasa@mail.com", Country = "United States", FoundationDate = new DateTime(1958, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "NASA" },
                        new { Id = 3551, City = "Warsaw", ContactEmail = "it@company.com", Country = "Poland", FoundationDate = new DateTime(2015, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "IT Company" },
                        new { Id = 4551, City = "Warsaw", ContactEmail = "job@reserved.pl", Country = "Poland", FoundationDate = new DateTime(1958, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Reserved" }
                    );
                });

            modelBuilder.Entity("JobApply.Models.JobApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ContactAgreement");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CvUrl");

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("OfferId");

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("JobApply.Models.JobOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ApplicationDeadline");

                    b.Property<string>("CompanyName")
                        .IsRequired();

                    b.Property<string>("ContractLength")
                        .IsRequired();

                    b.Property<DateTime>("Created");

                    b.Property<string>("JobDescription")
                        .IsRequired();

                    b.Property<string>("JobTitle")
                        .IsRequired();

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("SalaryDescription")
                        .IsRequired();

                    b.Property<int>("SalaryFrom");

                    b.Property<int>("SalaryTo");

                    b.Property<DateTime>("WorkStartDate");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("JobOffers");

                    b.HasData(
                        new { Id = 2546, ApplicationDeadline = new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CompanyName = "Kitchen", ContractLength = "1 year", Created = new DateTime(2020, 1, 14, 23, 46, 14, 431, DateTimeKind.Local), JobDescription = "Polish cuisine.", JobTitle = "Cook", Location = "Warsaw, Poland", SalaryDescription = "PLN/hour", SalaryFrom = 100, SalaryTo = 200, WorkStartDate = new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 3549, ApplicationDeadline = new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CompanyName = "NASA", ContractLength = "1 year", Created = new DateTime(2020, 1, 14, 23, 46, 14, 431, DateTimeKind.Local), JobDescription = "Space travel.", JobTitle = "Astronaut", Location = "Washington D.C.,United States", SalaryDescription = "US/travel", SalaryFrom = 10000, SalaryTo = 20000, WorkStartDate = new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 4549, ApplicationDeadline = new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), CompanyName = "IT Company", ContractLength = "2 years", Created = new DateTime(2020, 1, 14, 23, 46, 14, 431, DateTimeKind.Local), JobDescription = "ASP.NET core web applications.", JobTitle = "C# developer", Location = "Cracow, Poland", SalaryDescription = "PLN/month", SalaryFrom = 4000, SalaryTo = 5000, WorkStartDate = new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("JobApply.Models.JobApplication", b =>
                {
                    b.HasOne("JobApply.Models.JobOffer", "JobOffer")
                        .WithMany("JobApplications")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
