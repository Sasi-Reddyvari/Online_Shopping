using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XYZ_shops.Models;

namespace XYZ_shops.Controllers
{
    public class PasswordController : Controller
    {
       
        // GET: Password
        [HttpGet]
        public ActionResult Password()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Password(user lg)
        {
            using (xyzshopsEntities db = new xyzshopsEntities())
            {
                string s = lg.user_id;
                user dd = db.users.Find(s);
                string ss = dd.user_id;
                if(s==ss)
                {
                    dd.password = lg.password;
                    db.SaveChanges();
                    ViewBag.Message = "Password has changed succesfully";
                }
                else
                {
                    ViewBag.Message = "Your details were not found";
                }
                return View();
            }
                
        }
    }
}