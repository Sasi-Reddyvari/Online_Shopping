using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XYZ_shops.Models;

namespace XYZ_shops.Controllers
{
    public class AccountController : Controller
    {
        //Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(user objuser)
        {

            using (xyzshopsEntities db = new xyzshopsEntities())
            {
                var obj = db.users.Where(a => a.user_id.Equals(objuser.user_id) && a.password.Equals(objuser.password)).FirstOrDefault();
                ViewBag.Message = "";
                try
                {
                    if (obj.user_id == "sasiadmin" && obj.password == "sasiadmin")
                    {
                        Session["user_id"] = obj.user_id;
                        ViewBag.Message = "Admin is the user";
                        return RedirectToAction("Home", "Admin");
                    }
                    else if (obj == null)
                    {
                        //  objuser.LoginErrorMessage = "wrong user";
                        if (ViewBag.Message == null)
                        {
                            ViewBag.Message = "Wrong User Id or Password";
                        }

                        return View(objuser);
                    }
                    else
                    {

                        ViewBag.Message = obj.user_id + "is the user";
                        Session["user_id"] = obj.user_id;
                        return RedirectToAction("Home", "User");
                    }
                }
                catch (NullReferenceException)
                {
                    ViewBag.Message = "Wrong UserId or Password";
                    //   ModelState.AddModelError("", "Wrong UserId or Password");

                }
                return View(objuser);
            }

        }


        // Registration
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(user objuser)
        {
            bool status = false;
            string message = "";
                if (ModelState.IsValid)
                {
                    using (var d = new xyzshopsEntities())
                    {
                       d.users.Add(objuser);
                        d.SaveChanges();
                        message = "Registration sucess!!";
                        status = true;
                    }
                }
                else
                {
                    message = "Invalid request";
                }

            ViewBag.Message = message;
            ViewBag.Status = status;
            return View(objuser);
        }
        /*     [HttpPost]
         public JsonResult UserIdExists(string userid)
           {

               using (xyzshopsEntities db = new xyzshopsEntities())
               {
                   var userdetails=db
               }
                   return Json(!String.Equals(userid,userdetails.user_id, StringComparison.OrdinalIgnoreCase));
           }
           */
        
    }
}