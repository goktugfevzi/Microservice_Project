﻿// <auto-generated />
using Microservice.Services.Cargo.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Microservice.Services.Cargo.DataAccessLayer.Migrations
{
    [DbContext(typeof(CargoContext))]
    [Migration("20230814152143_initial_mig")]
    partial class initial_mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microservice.Services.Cargo.EntityLayer.Entities.CargoDetail", b =>
                {
                    b.Property<int>("CargoDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoDetailID"), 1L, 1);

                    b.Property<int>("CargoStateID")
                        .HasColumnType("int");

                    b.Property<int>("OrdersID")
                        .HasColumnType("int");

                    b.HasKey("CargoDetailID");

                    b.HasIndex("CargoStateID");

                    b.ToTable("CargoDetails");
                });

            modelBuilder.Entity("Microservice.Services.Cargo.EntityLayer.Entities.CargoState", b =>
                {
                    b.Property<int>("CargoStateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoStateID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CargoStateID");

                    b.ToTable("CargoStates");
                });

            modelBuilder.Entity("Microservice.Services.Cargo.EntityLayer.Entities.CargoDetail", b =>
                {
                    b.HasOne("Microservice.Services.Cargo.EntityLayer.Entities.CargoState", "CargoState")
                        .WithMany("CargoDetails")
                        .HasForeignKey("CargoStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CargoState");
                });

            modelBuilder.Entity("Microservice.Services.Cargo.EntityLayer.Entities.CargoState", b =>
                {
                    b.Navigation("CargoDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
