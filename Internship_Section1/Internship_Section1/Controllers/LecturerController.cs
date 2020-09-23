using Internship_Section1.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Internship_Section1.Controllers
{
    public class LecturerController : Controller
    {
        private Internship_Section1Entities db = new Internship_Section1Entities();

        // GET: Lecturer
        public ActionResult Index()
        {
            List<UserDetail> AList = new List<UserDetail>();
            using (Internship_Section1Entities DB = new Internship_Section1Entities())
            {
                
                foreach(var item in DB.UserDetails)
                {
                    if(item.Position == "Student")
                    {
                          AList.Add(item);
                        
               
                    }
                }
            }
                 return View(AList.ToList());
        }

        public ActionResult BachelorOfArts()
        {
            List<UserDetail> AList = new List<UserDetail>();
            using (Internship_Section1Entities DB = new Internship_Section1Entities())
            {

                foreach (var item in DB.UserDetails)
                {
                    if (item.Position == "Student" && item.LinkOfDegree == "BachelorOfArts")
                    {
                        AList.Add(item);


                    }
                }
            }
            return View(AList.ToList());
        }

        public ActionResult BachelorOfScience()
        {
            List<UserDetail> AList = new List<UserDetail>();
            using (Internship_Section1Entities DB = new Internship_Section1Entities())
            {

                foreach (var item in DB.UserDetails)
                {
                    if (item.Position == "Student" && item.LinkOfDegree == "BachelorOfScience")
                    {
                        AList.Add(item);


                    }
                }
            }
            return View(AList.ToList());
        }
        public ActionResult ProfileDetails()
        {
            foreach (var item in db.UserDetails)
            {
                if (item.EmailAddress == Session["Email"].ToString())
                {
                    List<UserDetail> AList = new List<UserDetail>();
                    AList.Add(item);
                    return View(AList.ToList());
                }


            }
            return View(db.UserDetails.ToList());
        }

        //EDIT
        //ProfileDetails Edit
        public ActionResult ProfileDetailsEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProfileDetailsEdit([Bind(Include = "UserID,Forenames,Surname,EmailAddress,DateOfBirth,FirstnameBasedOnForename,FullName,Position,ListOfDegree,LinkOfDegree,CourseName,DurationInMonths,CoursesPartOfDegree,DegreeName,DegreeDuringInYears,CoursesOfDegree")] UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProfileDetails");
            }
            return View(userDetail);
        }



        //DETAILS
        //All Students Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }
        //Bachelor of Arts Details
        public ActionResult BADetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }
        //Bachelor of Science Details
        public ActionResult BSDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }


        //EDIT
        //All Students Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Forenames,Surname,EmailAddress,DateOfBirth,FirstnameBasedOnForename,FullName,Position,ListOfDegree,LinkOfDegree,CourseName,DurationInMonths,CoursesPartOfDegree,DegreeName,DegreeDuringInYears,CoursesOfDegree")] UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDetail);
        }
        //Bachelor of Arts Edit
        public ActionResult BAEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BAEdit([Bind(Include = "UserID,Forenames,Surname,EmailAddress,DateOfBirth,FirstnameBasedOnForename,FullName,Position,ListOfDegree,LinkOfDegree,CourseName,DurationInMonths,CoursesPartOfDegree,DegreeName,DegreeDuringInYears,CoursesOfDegree")] UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BachelorOfArts");
            }
            return View(userDetail);
        }
        //Bachelor of Science Edit
        public ActionResult BSEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BSEdit([Bind(Include = "UserID,Forenames,Surname,EmailAddress,DateOfBirth,FirstnameBasedOnForename,FullName,Position,ListOfDegree,LinkOfDegree,CourseName,DurationInMonths,CoursesPartOfDegree,DegreeName,DegreeDuringInYears,CoursesOfDegree")] UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BachelorOfScience");
            }
            return View(userDetail);
        }

        //DELETE
        //All Students Delete
        //
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }
        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDetail userDetail = db.UserDetails.Find(id);
            db.UserDetails.Remove(userDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Bachelor of Arts Delete
        public ActionResult BADelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }
        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult BADeleteConfirmed(int id)
        {
            UserDetail userDetail = db.UserDetails.Find(id);
            db.UserDetails.Remove(userDetail);
            db.SaveChanges();
            return RedirectToAction("BachelorOfArts");
        }
        //Bachelor of Science Delete
        public ActionResult BSDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }
        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult BSDeleteConfirmed(int id)
        {
            UserDetail userDetail = db.UserDetails.Find(id);
            db.UserDetails.Remove(userDetail);
            db.SaveChanges();
            return RedirectToAction("BachelorOfScience");
        }

    }
}
