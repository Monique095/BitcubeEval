using Internship_Section1.Models;
using System.Linq;
using System.Web.Mvc;


namespace Internship_Section1.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    
        [HttpGet]
        // GET: User
        public ActionResult UserDetails(int id = 0)
        {
            UserDetail student = new UserDetail();

            return View(student);
        }

        [HttpPost]
        public ActionResult UserDetails(UserDetail userDetail)
        {
            using (Internship_Section1Entities DB = new Internship_Section1Entities())
            {
                if (DB.UserDetails.Any(x => x.EmailAddress == userDetail.EmailAddress))
                {
                    ViewBag.DuplicateMessage = "Already exist";

                    return View("UserDetails", userDetail);
                }
                else
                {

                    DB.UserDetails.Add(userDetail);
                    DB.SaveChanges();

                }

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Saved";


            return View("UserDetails", new UserDetail());

        }


        [AllowAnonymous]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(ViewLoginModel userModel)
        {
            using (Internship_Section1Entities DB = new Internship_Section1Entities())
            {
                if (ModelState.IsValid)
                {

                    var user = (from list in DB.UserDetails
                                where list.EmailAddress == userModel.EmailAddress
                                select new
                                {
                                    list.UserID,
                                    list.EmailAddress,
                                    list.Position

                                }).ToList();
                    if (user.FirstOrDefault() != null)
                    {
                        Session["Email"] = user.FirstOrDefault().EmailAddress;
                        Session["StudentID"] = user.FirstOrDefault().UserID;
                        Session["Position"] = user.FirstOrDefault().Position;


                        if (Session["Position"].ToString() == "Student") //ONLY the Admin Role 
                        {
                            return RedirectToAction("ProfileDetails", "Students"); //The Views they can see
                        }
                        if (Session["Position"].ToString() == "Lecturer")  //ONLY the Moderator Role 
                        {
                            return RedirectToAction("Index", "Lecturer");  //The Views they can see
                        }



                    }
                    else
                    {
                        //When the user entered the wrong login details this message will appear.
                        ModelState.AddModelError("", "Invalid login credentials.");
                        return View(); //The login view will reappear.
                    }




                }
                return View(userModel);
            }

        }


        //Log out User which is logged in.
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "User");
        }

    
    }
}