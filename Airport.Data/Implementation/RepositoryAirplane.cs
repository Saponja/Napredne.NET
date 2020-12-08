using Airport.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Airport.Data.Implementation
{
    public class RepositoryAirplane : IRepositoryAirplane
    {
        private AirportContext context;
        public RepositoryAirplane(AirportContext context)
        {
            this.context = context;
        }
        public void Add(Airplane item)
        {
            context.Airplanes.Add(item);
        }

        public void AddSeatToAirplane(Seat s, int airplainId)
        {
            s.AirplaneId = airplainId;
            Airplane a = context.Airplanes.Single(a => a.AirplaneId == airplainId);
            a.Seats.Add(s);
        }

        public Airplane FindById(int id)
        {
            return context.Airplanes.Find(id);
        }

        public List<Airplane> GetAll()
        {
            return context.Airplanes.ToList();
        }

        public List<Passanger> GetAllPassangersFromAirplane(int id)
        {
            List<Seat> seats = context.Airplanes.Include(a => a.Seats).Single(a => a.AirplaneId == id).Seats;
            List<Passanger> passangers = new List<Passanger>();
            foreach (var item in seats)
            {
                List<Reservation> reservations = context.Reservations.Include(r => r.Passanger).Where(r => r.SeatId == item.SeatId).ToList();
                foreach (var res in reservations)
                {
                    passangers.Add(res.Passanger);
                }
            }

            return passangers;
        }

        public void Remove(Airplane item)
        {
            context.Airplanes.Remove(item);
        }

        public List<Seat> GetAllSeatsFromAirplane(int id)
        {
            return context.Airplanes.Include(a => a.Seats).Single(a => a.AirplaneId == id).Seats;
        }

    }
}
