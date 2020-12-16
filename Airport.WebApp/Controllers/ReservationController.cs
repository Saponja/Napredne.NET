using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Airport.Data.UnitOfWork;
using Airport.Domain;
using Airport.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airport.WebApp.Controllers
{

    public class ReservationController : Controller
    {
        private readonly IUnitOfWork uow;

        public ReservationController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpPost]
        [ActionName("CreateReservation")]
        public ActionResult Create([FromForm]ReservationViewModel model)
        {
            if (!DateTime.TryParseExact(model.Date, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime date))
            {
                ModelState.AddModelError("DateError", "Date must be in dd.MM.yyyy HH:mm format ");
                return Create();
            }

            if(date < DateTime.Now)
            {
                ModelState.AddModelError("DateError2", "Date must be grater then today");
                return Create();
            }

            Reservation reservation = new Reservation
            {
                PassangerId = model.PassangerId,
                SeatId = model.SeatId,
                DateOfReservation = date
                
            };


            uow.Reservation.Add(reservation);
            uow.Commit();
            return RedirectToAction("Index", "Passanger", uow.Passanger.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> passangers = new List<SelectListItem>();
            foreach (Passanger passanger in uow.Passanger.GetAll())
            {
                passangers.Add(new SelectListItem { Value = passanger.PassangerId.ToString(), Text = passanger.FirstName + " " + passanger.LastName });
            }

            List<SelectListItem> seats = new List<SelectListItem>();
            foreach (Seat seat in uow.Seat.GetAll())
            {
                Airplane a = uow.Airplane.FindById(seat.AirplaneId);
                string airplaneName = a.Name;
                seats.Add(new SelectListItem { Value = seat.SeatId.ToString(), Text = a.Name + "/" + seat.Class });
            }

            ReservationViewModel model = new ReservationViewModel
            {
                Seats = seats,
                Passangers = passangers
            };

            return View("CreateReservation", model);
        }
    }
}
