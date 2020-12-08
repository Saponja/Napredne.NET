using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Airport.Data.Implementation
{
    public class RepositoryReservation : IRepositoryReservation
    {

        private AirportContext context;
        public RepositoryReservation(AirportContext context)
        {
            this.context = context;
        }
        public void Add(Reservation item)
        {
            context.Reservations.Add(item);
        }

        public Reservation FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAll()
        {
            return context.Reservations.ToList();
        }

        public void Remove(Reservation item)
        {
            throw new NotImplementedException();
        }
    }
}
