using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Checkpoint4.DAL;
using Checkpoint4.Models;

namespace Checkpoint4.Controllers
{
    public class HomeController : Controller
    {
        private BlowOutContext db = new BlowOutContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Rentals()
        {
            return View(db.Instruments.ToList());
        }

        [HttpGet]
        public ActionResult Create(int ID)
        {
            Instrument instrument = db.Instruments.Find(ID);

            ViewBag.price = instrument.price;
            ViewBag.name = instrument.type + ' ' + instrument.description;

            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clientID,firstName,lastName,address,city,state,zip,email,phone")] Client client, int ID)
        {
            if (ModelState.IsValid)
            {
                //add new client to database and save changes
                db.Clients.Add(client);
                db.SaveChanges();

                //lookup instrument from table
                Instrument instrument = db.Instruments.Find(ID);
                //update instrument's clientID
                instrument.clientID = client.clientID;
                db.Entry(instrument).State = System.Data.Entity.EntityState.Modified;
                //save changes
                db.SaveChanges();

                return RedirectToAction("Summary", new { clientID = client.clientID, instrumentID = instrument.instrumentID });
            }

            return View(client);
        }

        public ActionResult Summary(int clientID, int instrumentID)
        {
            Client client = db.Clients.Find(clientID);
            Instrument instrument = db.Instruments.Find(instrumentID);

            //Create instance of client and instrument classes and pass to viewBag
            ViewBag.Client = client;
            ViewBag.Instrument = instrument;
            ViewBag.TotalPayments = instrument.price * 18;

            //switch statement to pass all instrument attributes to ViewBag
            switch (instrument.description)
            {
                case "Trumpet":
                    ViewBag.image = "Trumpet .png";
                    break;
                case "Trombone":
                    ViewBag.image = "Trombone .png";
                    break;
                case "Tuba":
                    ViewBag.image = "Tuba .png";
                    break;
                case "Clarinet":
                    ViewBag.image = "Clarinet .png";
                    break;
                case "Flute":
                    ViewBag.image = "Flute .png";
                    break;
                case "Saxophone":
                    ViewBag.image = "Saxophone .png";
                    break;
            }

            return View();
        }
    }
}