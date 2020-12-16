using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Data.UnitOfWork;
using Airport.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airport.WebApp.Controllers
{
    public class PassangerController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public PassangerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            List<Passanger> model = unitOfWork.Passanger.GetAll();
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult Details([FromRoute]int id)
        {
            Passanger model = unitOfWork.Passanger.FindById(id);
            return View(model);
        }

        [HttpGet, ActionName("Seats")]
        public ActionResult PassangersSeats([FromRoute]int id)
        {
            List<Seat> model = unitOfWork.Passanger.GetPassangersSeats(id);
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View("CreatePassanger");
        }

        [HttpPost]
        public ActionResult Create([FromForm]Passanger passanger)
        {
            if (!ModelState.IsValid)
            {
                return View("CreatePassanger");
            }

            bool exists = unitOfWork.Passanger.Search(p => p.FirstName == passanger.FirstName).Any();

            if (exists)
            {
                ModelState.AddModelError("PassangerName", "Passanger with this name already exists!");
                return View("CreatePassanger");
            }

            unitOfWork.Passanger.Add(passanger);
            unitOfWork.Commit();
            //return View("Index", unitOfWork.Passanger.GetAll());
            return Index();
        }

        [HttpPost]
        public ActionResult Delete([FromRoute]int id)
        {
            Passanger p = unitOfWork.Passanger.GetAll().Single(p => p.PassangerId == id);
            unitOfWork.Passanger.Remove(p);
            unitOfWork.Commit();
            return Index();
        }


    }
}
