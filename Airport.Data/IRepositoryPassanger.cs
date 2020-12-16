using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Airport.Data
{
    public interface IRepositoryPassanger : IRepository<Passanger>
    {
        public void GetPassangersWithSeats();
        public List<Seat> GetPassangersSeats(int id);
        List<Passanger> Search(Expression<Func<Passanger, bool>> p);
    }
}
