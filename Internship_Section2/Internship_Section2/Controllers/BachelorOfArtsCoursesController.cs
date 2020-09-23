using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Internship_Section2.Models;

namespace Internship_Section2.Controllers
{
    public class BachelorOfArtsCoursesController : Controller
    {
        private Internship_Section2Entities db = new Internship_Section2Entities();

        // GET: BachelorOfArtsCourses
        public ActionResult Index()
        {
            var bACourses = db.BACourses.Include(b => b.Degree);
            return View(bACourses.ToList());
        }

        // GET: BachelorOfArtsCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BACourse bACourse = db.BACourses.Find(id);
            if (bACourse == null)
            {
                return HttpNotFound();
            }
            return View(bACourse);
        }

        // GET: BachelorOfArtsCourses/Create
        public ActionResult Create()
        {
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "Degree1");
            return View();
        }

        // POST: BachelorOfArtsCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BAID,DegreeID,DegreeName,DurationInYears,Courses")] BACourse bACourse)
        {
            if (ModelState.IsValid)
            {
                db.BACourses.Add(bACourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "Degree1", bACourse.DegreeID);
            return View(bACourse);
        }

        // GET: BachelorOfArtsCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BACourse bACourse = db.BACourses.Find(id);
            if (bACourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "Degree1", bACourse.DegreeID);
            return View(bACourse);
        }

        // POST: BachelorOfArtsCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BAID,DegreeID,DegreeName,DurationInYears,Courses")] BACourse bACourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bACourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "Degree1", bACourse.DegreeID);
            return View(bACourse);
        }

        // GET: BachelorOfArtsCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BACourse bACourse = db.BACourses.Find(id);
            if (bACourse == null)
            {
                return HttpNotFound();
            }
            return View(bACourse);
        }

        // POST: BachelorOfArtsCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BACourse bACourse = db.BACourses.Find(id);
            db.BACourses.Remove(bACourse);
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
