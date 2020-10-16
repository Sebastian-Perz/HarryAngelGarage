using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HarryAngelGarage.DAL;
using HarryAngelGarage.Models;
using PagedList;

namespace HarryAngelGarage.Controllers
{
    public class CarController : Controller
    {
        private HarryAngelGarageContext db = new HarryAngelGarageContext();

        // GET: Cars
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.BrandSortParm = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var cars = from s in db.Cars
                       select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Client.FirstName.Contains(searchString)
                                       || s.Client.LastName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    cars = cars.OrderByDescending(s => s.Client.LastName);
                    break;
                case "brand_desc":
                    cars = cars.OrderByDescending(s => s.Brand);
                    break;
                case "Date":
                    cars = cars.OrderBy(s => s.CarHandInDate);
                    break;
                case "date_desc":
                    cars = cars.OrderByDescending(s => s.CarHandInDate);
                    break;
                default:  // Name ascending 
                    cars = cars.OrderBy(s => s.CarHandInDate);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(cars.ToPagedList(pageNumber, pageSize));
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "FullName");
            ViewBag.WorkerID = new SelectList(db.Workers, "WorkerID", "FullName");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarID,ClientID,WorkerID,Brand,Model,CarHandInDate,ProductionYear,BodyStyleType,VIN")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ID", "LastName", car.ClientID);
            ViewBag.WorkerID = new SelectList(db.Workers, "WorkerID", "FirstName", car.WorkerID);
            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "FullName", car.ClientID);
            ViewBag.WorkerID = new SelectList(db.Workers, "WorkerID", "FullName", car.WorkerID);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarID,ClientID,WorkerID,Brand,Model,CarHandInDate,ProductionYear,BodyStyleType,VIN")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "LastName", car.ClientID);
            ViewBag.WorkerID = new SelectList(db.Workers, "WorkerID", "FirstName", car.WorkerID);
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
