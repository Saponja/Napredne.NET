using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepositoryAirplane Airplane { get; set; }
        public IRepositoryPassanger Passanger { get; set; }
        public IRepositoryReservation Reservation { get; set; }

        void Commit();
    }
}
