using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Internship_Section3.Models;

namespace Internship_Section3.Controllers
{
    public class StudentsController : Controller
    {
        private Internship_Section3Entities db = new Internship_Section3Entities();

        // GET: Students
        public ActionResult Index()
        {

            List<Student> AList = new List<Student>();

            foreach (var item in db.Students)
            {
                if (item.Position == "Student")
                {
                    AList.Add(item);

                }

            }
            var students = db.Students.Include(s => s.Lecturer);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName");
            return View();
        }


        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,Forenames,Surnames,EmailAddress,DateOfBirth,FullName,Position,DegreeSt,LecturerID")] Student student)
        {
            if (db.Students.Any(x => x.EmailAddress == student.EmailAddress))
            {
                ViewBag.DuplicateMessage = "Already exist";

                return View("Create", student);
            }
            else
            {

                db.Students.Add(student);
                db.SaveChanges();

            }

            ModelState.Clear();
            ViewBag.SuccessMessage = "Saved Successfully!";

            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", student.LecturerID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", student.LecturerID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,Forenames,Surnames,EmailAddress,DateOfBirth,FullName,Position,DegreeSt,LecturerID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", student.LecturerID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
