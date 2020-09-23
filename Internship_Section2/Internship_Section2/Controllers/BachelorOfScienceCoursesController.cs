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
    public class BachelorOfScienceCoursesController : Controller
    {
        private Internship_Section2Entities db = new Internship_Section2Entities();

        // GET: BachelorOfScienceCourses
        public ActionResult Index()
        {
            var bSCourses = db.BSCourses.Include(b => b.Degree);
            return View(bSCourses.ToList());
        }

        // GET: BachelorOfScienceCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSCourse bSCourse = db.BSCourses.Find(id);
            if (bSCourse == null)
            {
                return HttpNotFound();
            }
            return View(bSCourse);
        }

        // GET: BachelorOfScienceCourses/Create
        public ActionResult Create()
        {
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "Degree1");
            return View();
        }

        // POST: BachelorOfScienceCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BSID,DegreeID,DegreeName,DurationInYears,Courses")] BSCourse bSCourse)
        {
            if (ModelState.IsValid)
            {
                db.BSCourses.Add(bSCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "Degree1", bSCourse.DegreeID);
            return View(bSCourse);
        }

        // GET: BachelorOfScienceCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSCourse bSCourse = db.BSCourses.Find(id);
            if (bSCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "Degree1", bSCourse.DegreeID);
            return View(bSCourse);
        }

        // POST: BachelorOfScienceCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BSID,DegreeID,DegreeName,DurationInYears,Courses")] BSCourse bSCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bSCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "Degree1", bSCourse.DegreeID);
            return View(bSCourse);
        }

        // GET: BachelorOfScienceCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSCourse bSCourse = db.BSCourses.Find(id);
            if (bSCourse == null)
            {
                return HttpNotFound();
            }
            return View(bSCourse);
        }

        // POST: BachelorOfScienceCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BSCourse bSCourse = db.BSCourses.Find(id);
            db.BSCourses.Remove(bSCourse);
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
