using Airport.Domain.Validation;
using System.Collections.Generic;

namespace Airport.Domain
{
    public class Passanger
    {
        public int PassangerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [PassangerAge (ErrorMessage = "Age must be between 3 and 93")]
        public int Age { get; set; }
        public List<Reservation> Seats { get; set; }

        public override string ToString()
        {
            string s = $"{FirstName}";
            foreach (var item in Seats)
            {
                s += item.Seat.ToString();
            }
            return s;
        }
    }
}