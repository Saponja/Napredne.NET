using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Airport.Domain
{
    public class AirportContext : DbContext
    {
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Passanger> Passangers { get; set; }

        public DbSet<Reservation> Reservations { get; set; }


        public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Airport;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Airplane>(a =>
            //{
            //    a.OwnsMany(a => a.Seats);
            //});

            modelBuilder.Entity<Reservation>(r =>
            {
                r.HasKey(r => new { r.SeatId, r.PassangerId, r.DateOfReservation });
                r.HasOne(r => r.Seat).WithMany(s => s.Passangers).OnDelete(DeleteBehavior.Restrict);
                r.HasOne(r => r.Passanger).WithMany(p => p.Seats).OnDelete(DeleteBehavior.Restrict);
            });



        }




    }
}
