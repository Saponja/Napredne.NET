using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Airport.Data.Implementation
{
    public class RepositorySeat : IRepositorySeat
    {
        private AirportContext context;

        public RepositorySeat(AirportContext context)
        {
            this.context = context;
        }

        public void Add(Seat item)
        {
            context.Seat.Add(item);
        }

        public Seat FindById(int id)
        {
            return context.Seat.Single(s => s.SeatId == id);
        }

        public List<Seat> GetAll()
        {
            //List<Airplane> airplanes = context.Airplanes.Include(a => a.Seats).ToList();
            //List<Seat> seats = new List<Seat>();
            //foreach (Airplane airplane in airplanes)
            //{
            //    foreach (Seat seat in airplane.Seats)
            //    {
            //        seats.Add(seat);
            //    }
            //}

            //return seats;

            return context.Seat.ToList();
        }

        public void Remove(Seat item)
        {
            context.Seat.Remove(item);
        }
    }
}
