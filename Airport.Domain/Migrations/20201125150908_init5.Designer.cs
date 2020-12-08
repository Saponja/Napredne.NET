﻿// <auto-generated />
using System;
using Airport.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Airport.Domain.Migrations
{
    [DbContext(typeof(AirportContext))]
    [Migration("20201125150908_init5")]
    partial class init5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Airport.Domain.Airplane", b =>
                {
                    b.Property<int>("AirplaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Company")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AirplaneId");

                    b.ToTable("Airplanes");
                });

            modelBuilder.Entity("Airport.Domain.Passanger", b =>
                {
                    b.Property<int>("PassangerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassangerId");

                    b.ToTable("Passangers");
                });

            modelBuilder.Entity("Airport.Domain.Reservation", b =>
                {
                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<int>("PassangerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfReservation")
                        .HasColumnType("datetime2");

                    b.HasKey("SeatId", "PassangerId", "DateOfReservation");

                    b.HasIndex("PassangerId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Airport.Domain.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AirplaneId")
                        .HasColumnType("int");

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("SeatId");

                    b.HasIndex("AirplaneId");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("Airport.Domain.Reservation", b =>
                {
                    b.HasOne("Airport.Domain.Passanger", "Passanger")
                        .WithMany("Seats")
                        .HasForeignKey("PassangerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Airport.Domain.Seat", "Seat")
                        .WithMany("Passangers")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Passanger");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("Airport.Domain.Seat", b =>
                {
                    b.HasOne("Airport.Domain.Airplane", null)
                        .WithMany("Seats")
                        .HasForeignKey("AirplaneId");
                });

            modelBuilder.Entity("Airport.Domain.Airplane", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("Airport.Domain.Passanger", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("Airport.Domain.Seat", b =>
                {
                    b.Navigation("Passangers");
                });
#pragma warning restore 612, 618
        }
    }
}
