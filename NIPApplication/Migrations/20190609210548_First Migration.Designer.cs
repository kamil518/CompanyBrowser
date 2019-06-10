﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NIPApplication.Persistance;

namespace NIPApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190609210548_First Migration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("NIPApplication.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Krs");

                    b.Property<string>("Name");

                    b.Property<string>("Nip");

                    b.Property<string>("NipCountryCode")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("PL");

                    b.Property<string>("PostCode");

                    b.Property<string>("Regon");

                    b.Property<string>("Street");

                    b.Property<string>("StreetNumber");

                    b.HasKey("Id");

                    b.HasIndex("Krs")
                        .IsUnique();

                    b.HasIndex("Nip")
                        .IsUnique();

                    b.HasIndex("Regon")
                        .IsUnique();

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Poznan",
                            Krs = "0000231231",
                            Name = "GSK Services SP z O O",
                            Nip = "7792254227",
                            PostCode = "60-322",
                            Regon = "300040065",
                            Street = "Grunwaldzka",
                            StreetNumber = "189"
                        },
                        new
                        {
                            Id = 2,
                            City = "Warszawa",
                            Krs = "0000240611",
                            Name = "Google Poland SP z O O",
                            Nip = "5252344078",
                            PostCode = "00-113",
                            Regon = "140182840",
                            Street = "Emilii Plater",
                            StreetNumber = "53"
                        },
                        new
                        {
                            Id = 3,
                            City = "Warszawa",
                            Krs = "0000056838",
                            Name = "Microsoft SP z O O",
                            Nip = "5270103391",
                            PostCode = "02-222",
                            Regon = "010016565",
                            Street = "Aleje Jerozolimskie",
                            StreetNumber = "195A"
                        });
                });

            modelBuilder.Entity("NIPApplication.Models.CompanySearchQuery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Query");

                    b.Property<int>("QueryType");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("Timestamp")
                        .IsUnique();

                    b.ToTable("CompanySearchQueries");
                });
#pragma warning restore 612, 618
        }
    }
}
