using Airport.Domain;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Airport.Data.Implementation
{
    class RepositoryPassanger : IRepositoryPassanger
    {

        private AirportContext context;
        public RepositoryPassanger(AirportContext context)
        {
            this.context = context;
        }
        public void Add(Passanger item)
        {
            context.Passangers.Add(item);
        }

        public Passanger FindById(int id)
        {
            return context.Passangers.Find(id);
        }

        public List<Passanger> GetAll()
        {
            return context.Passangers.ToList();
        }

        public void GetPassangersWithSeats()
        {
            foreach(Passanger p in context.Passangers.Include(p => p.Seats).ThenInclude(s => s.Seat))
            {
                Console.WriteLine(p.ToString());
            }
        }

        public List<Seat> GetPassangersSeats(int id)
        {
            List<Seat> seats = context.Passangers.Include(p => p.Seats).ThenInclude(s => s.Seat).Single(p => p.PassangerId == id).Seats.Where(s => s.PassangerId == id).Select(s => s.Seat).ToList();
            //return context.Passangers.Single(p => p.PassangerId == id).Seats.Where(s => s.PassangerId == id).Select(s => s.Seat).ToList();
            return seats;
        }

        public void Remove(Passanger item)
        {
            context.Passangers.Remove(item);
        }

        public List<Passanger> Search(Expression<Func<Passanger, bool>> p)
        {
            return context.Passangers.Where(p).ToList();
        }
    }
}
