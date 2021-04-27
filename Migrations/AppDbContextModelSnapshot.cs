﻿// <auto-generated />
using System;
using GKU_App.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GKU_App.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.HasSequence("serial")
                .StartsAt(100000000L);

            modelBuilder.Entity("GKU_App.Models.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("BuildingId");

                    b.HasIndex("CityId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("GKU_App.Models.Charge", b =>
                {
                    b.Property<int>("PropertyId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ChargeDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Volume")
                        .HasColumnType("double precision");

                    b.HasKey("PropertyId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Charges");
                });

            modelBuilder.Entity("GKU_App.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("GKU_App.Models.Owner", b =>
                {
                    b.Property<int>("PersonalAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('serial'::regclass)");

                    b.Property<int>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("integer");

                    b.Property<int>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("integer");

                    b.Property<int>("Patronymic")
                        .HasMaxLength(30)
                        .HasColumnType("integer");

                    b.HasKey("PersonalAccount");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("GKU_App.Models.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ApartmentNumber")
                        .HasMaxLength(30)
                        .HasColumnType("integer");

                    b.Property<int>("BuildingId")
                        .HasColumnType("integer");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<double>("Square")
                        .HasMaxLength(30)
                        .HasColumnType("double precision");

                    b.HasKey("PropertyId");

                    b.HasIndex("BuildingId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("GKU_App.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("GKU_App.Models.ServiceCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceCompanies");
                });

            modelBuilder.Entity("GKU_App.Models.Tariff", b =>
                {
                    b.Property<int>("BuildingId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("BuildingId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Tariffs");
                });

            modelBuilder.Entity("GKU_App.Models.Building", b =>
                {
                    b.HasOne("GKU_App.Models.City", "City")
                        .WithMany("Buildings")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("GKU_App.Models.Charge", b =>
                {
                    b.HasOne("GKU_App.Models.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GKU_App.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("GKU_App.Models.Property", b =>
                {
                    b.HasOne("GKU_App.Models.Building", "Building")
                        .WithMany("Properties")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GKU_App.Models.Owner", "Owner")
                        .WithMany("Properties")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("GKU_App.Models.ServiceCompany", b =>
                {
                    b.HasOne("GKU_App.Models.Service", "Service")
                        .WithMany("ServiceCompanies")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("GKU_App.Models.Tariff", b =>
                {
                    b.HasOne("GKU_App.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GKU_App.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("GKU_App.Models.Building", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("GKU_App.Models.City", b =>
                {
                    b.Navigation("Buildings");
                });

            modelBuilder.Entity("GKU_App.Models.Owner", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("GKU_App.Models.Service", b =>
                {
                    b.Navigation("ServiceCompanies");
                });
#pragma warning restore 612, 618
        }
    }
}
