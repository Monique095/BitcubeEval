using Internship_Section1.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Internship_Section1.Controllers
{
    public class DegreesController : Controller
    {
        private Internship_Section1Entities db = new Internship_Section1Entities();

        // GET: Degrees
        public ActionResult Index(UserDetail userDetail, Degree degree)
        {
            foreach(var item in db.UserDetails)
            {
                if(item.Position == "Lecturer")
                {
                    var degrees = db.Degrees.Include(d => d.UserDetail);
                    return View(degrees.ToList());
                }
            }
            return View(db.Degrees.ToList());
        }

        // GET: Degrees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // GET: Degrees/Create
        public ActionResult Create(UserDetail userDetail)
        {
        
            
                ViewBag.UserID = new SelectList(db.UserDetails, "UserID", "FullName");
            
               
            return View();
        }

        // POST: Degrees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DegreeID,DegreeName,DegreeDuringInYears,CoursesOfDegree,UserID")] Degree degree)
        {
           
            if (ModelState.IsValid)
            {
                db.Degrees.Add(degree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.UserID = new SelectList(db.UserDetails, "UserID", "FullName", degree.UserID);
            
               
           
            return View(degree);
        }

        // GET: Degrees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.UserDetails, "UserID", "Forenames", degree.UserID);
            return View(degree);
        }

        // POST: Degrees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DegreeID,DegreeName,DegreeDuringInYears,CoursesOfDegree,UserID")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.UserDetails, "UserID", "Forenames", degree.UserID);
            return View(degree);
        }

        // GET: Degrees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Degree degree = db.Degrees.Find(id);
            db.Degrees.Remove(degree);
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
