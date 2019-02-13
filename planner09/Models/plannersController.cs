using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace planner09.Models
{
    public class plannersController : Controller
    {
        private plannerDBContext db = new plannerDBContext();

        // GET: planners
        public ActionResult Index()
        {
            return View(db.planners.ToList());
        }

        // GET: planners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planner planner = db.planners.Find(id);
            if (planner == null)
            {
                return HttpNotFound();
            }
            return View(planner);
        }

        // GET: planners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: planners/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AppointmentDate,Description")] planner planner)
        {
            if (ModelState.IsValid)
            {
                db.planners.Add(planner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planner);
        }

        // GET: planners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planner planner = db.planners.Find(id);
            if (planner == null)
            {
                return HttpNotFound();
            }
            return View(planner);
        }

        // POST: planners/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AppointmentDate,Description")] planner planner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planner);
        }

        // GET: planners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planner planner = db.planners.Find(id);
            if (planner == null)
            {
                return HttpNotFound();
            }
            return View(planner);
        }

        // POST: planners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            planner planner = db.planners.Find(id);
            db.planners.Remove(planner);
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
