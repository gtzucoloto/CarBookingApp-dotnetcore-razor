﻿// <auto-generated />
using System;
using CarBookingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarBookingApp.Data.Migrations
{
    [DbContext(typeof(CarBookingAppDbContext))]
    [Migration("20210825230007_CorrectedTableNames")]
    partial class CorrectedTableNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarBookingApp.Data.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarModelId")
                        .HasColumnType("int");

                    b.Property<int?>("ColourId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicensePlateNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("MakeId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.HasIndex("ColourId");

                    b.HasIndex("MakeId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarBookingApp.Data.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("CarBookingApp.Data.Colour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colours");
                });

            modelBuilder.Entity("CarBookingApp.Data.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("CarBookingApp.Data.Car", b =>
                {
                    b.HasOne("CarBookingApp.Data.CarModel", "CarModel")
                        .WithMany("Cars")
                        .HasForeignKey("CarModelId");

                    b.HasOne("CarBookingApp.Data.Colour", "Colour")
                        .WithMany("Cars")
                        .HasForeignKey("ColourId");

                    b.HasOne("CarBookingApp.Data.Make", "Make")
                        .WithMany("Cars")
                        .HasForeignKey("MakeId");

                    b.Navigation("CarModel");

                    b.Navigation("Colour");

                    b.Navigation("Make");
                });

            modelBuilder.Entity("CarBookingApp.Data.CarModel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarBookingApp.Data.Colour", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarBookingApp.Data.Make", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
