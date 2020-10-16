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
using HarryAngelGarage.ViewModels;

namespace HarryAngelGarage.Controllers
{
    public class WorkerController : Controller
    {

        private HarryAngelGarageContext db = new HarryAngelGarageContext();

        // GET: Worker
        public ActionResult Index(int? id, int? carID)
        {
            var viewModel = new WorkerData();
            viewModel.Workers = db.Workers
                .Include(i => i.Helpers)
                .Include(i => i.Cars.Select(c => c.Client))
                .OrderBy(i => i.LastName);

            if (id != null)
            {
                ViewBag.WorkerID = id.Value;
                viewModel.Cars = viewModel.Workers.Where(
                    i => i.WorkerID == id.Value).Single().Cars;
            }

            if (carID != null)
            {
                ViewBag.CarID = carID.Value;
                viewModel.Helpers = viewModel.Cars.Where(
                    x => x.CarID == carID).Single().Helpers;
            }
            return View(viewModel);

        }

        // GET: Worker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: Worker/Create
        public ActionResult Create()
        {
            ViewBag.GarageID = new SelectList(db.Garages, "GarageID", "GarageID");
            return View();
        }

        // POST: Worker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkerID,GarageID,FirstName,LastName,BirthYear,Salary")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(worker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GarageID = new SelectList(db.Garages, "GarageID", "GarageID", worker.GarageID);
            return View(worker);
        }

        // GET: Worker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            ViewBag.GarageID = new SelectList(db.Garages, "GarageID", "GarageID", worker.GarageID);
            return View(worker);
        }

        // POST: Worker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkerID,GarageID,FirstName,LastName,BirthYear,Salary")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GarageID = new SelectList(db.Garages, "GarageID", "GarageID", worker.GarageID);
            return View(worker);
        }

        // GET: Worker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Worker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker worker = db.Workers.Find(id);
            db.Workers.Remove(worker);
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
