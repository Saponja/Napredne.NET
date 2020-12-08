using System;
using System.Collections.Generic;

namespace Airport.Domain
{

    public enum Company
    {
        Aeroflot,
        Lufthansa,
        BritishAirways,
        TurkishAirlines,
        QuatarAirways,
        AirSerbia
    }
    public class Airplane
    {
        public int AirplaneId { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public string Model { get; set; }
        public List<Seat> Seats { get; set; }

        public override string ToString()
        {
            string s = $"{Name}";
            foreach (var item in Seats)
            {
                s += item.ToString();
            }

            return s;
        }
    }
}
