using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Data
{
    public interface IRepositoryPassanger : IRepository<Passanger>
    {
        public void GetPassangersWithSeats();
        public List<Seat> GetPassangersSeats(int id);
        
    }
}
