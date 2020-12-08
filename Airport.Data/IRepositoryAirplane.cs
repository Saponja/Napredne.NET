using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Data
{
    public interface IRepositoryAirplane : IRepository<Airplane>
    {
        public void AddSeatToAirplane(Seat s, int airplainId);
        public List<Passanger> GetAllPassangersFromAirplane(int id);
        List<Seat> GetAllSeatsFromAirplane(int id);
    }
}
