using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.WebApp.Models
{
    public class ReservationViewModel
    {
        public int PassangerId { get; set; }
        public int SeatId { get; set; }

        public List<SelectListItem> Passangers { get; set; }
        public List<SelectListItem> Seats { get; set; }
        public string Date { get; set; }




    }
}
