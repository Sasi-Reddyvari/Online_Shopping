using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XYZ_shops.Models;

namespace XYZ_shops.Controllers
{
    public class CategoriesController : Controller
    {
        private xyzshopsEntities db = new xyzshopsEntities();

        // GET: Categories
        public ActionResult Sweatshirts()
        {
            return View(db.products.ToList());
        }
        public ActionResult Jeans()
        {
            return View(db.products.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            Session["product_name"] = product.product_name;
            return View(product);
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