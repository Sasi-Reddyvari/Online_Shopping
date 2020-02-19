using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XYZ_shops.Models;

namespace XYZ_shops.Controllers
{
    public class UserController : Controller
    {
        private xyzshopsEntities db = new xyzshopsEntities();
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index(string Search_by, string Search)
        {
            if (Search_by == "product_name")
            {
                return View(db.products.Where(x => x.product_name == Search || Search == null).ToList());
            }
            else
            {
                return View(db.products.Where(x => x.product_category == Search || Search == null).ToList());
            }
        }
        public ActionResult Sweatshirts()
            {
                return View(db.products.ToList());
            }

        public ActionResult Jeans()
            {
                return View(db.products.ToList());
            }
        [HttpGet]
        public ActionResult OrderNow()
        {
            return View(db.orders.Where(a => a.user_id.Equals(Session["user_id"])).ToList());

        }
        [HttpPost]
        public ActionResult OrderNow(int id)
        {
            order obj = new order();
            product p = db.products.Find(Session["pid"]);
            obj.user_id = Session["user_id"].ToString();
            obj.product_id = id;
            obj.product_category = p.product_category;
            obj.product_name = p.product_name;
            obj.product_price = p.product_price;
            return View(db.orders.Where(a => a.user_id.Equals(Session["user_id"])).ToList());

        }

        public ActionResult Details(int id)
            {
                //if (id == null)
                //{
                //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //}
                product product = db.products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                Session["product_name"] = product.product_name;
                Session["product_id"] = id;
                return View(product);
            }

            
        [HttpGet]
        public ActionResult Cart(int id)
        {
            Session["pid"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult Cart(cart obj)
        {
            product p = db.products.Find(Session["pid"]);
            obj.product_id= p.product_id;
            obj.user_id = Session["user_id"].ToString();
            obj.product_image = p.product_image;
            obj.product_name = p.product_name;
            obj.product_price = p.product_price;
            using (var d = new xyzshopsEntities())
            {
                d.carts.Add(obj);
                d.SaveChanges();
                
            }
            return RedirectToAction("CartView");
        }

        public ActionResult CartView()
        {
             cart obj = new cart();
             
            obj.user_id = Session["user_id"].ToString();
            //var d = db.carts.Where(a => a.user_id.Equals(obj.user_id)).FirstOrDefault();
            //if (d.ToString() == obj.user_id)
            if(Session["user_id"]!=null)
            {
                return View(db.carts.Where(a => a.user_id.Equals(obj.user_id)).ToList());
            }
            else
            {
                ViewBag.message = "No Items in Your Cart";
            }
            return View();
        }


        public ActionResult Delete(int id)
         {
            string s = Session["user_id"].ToString();
            
            cart obj= db.carts.Find(id);
           
            if (obj == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.carts.Remove(obj);
                db.SaveChanges();
                return View(db.carts.Where(a => a.user_id.Equals(Session["user_id"])).ToList());
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cart product = db.carts.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,product_name,product_category,product_price,product_description,product_image")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

      
        public ActionResult About()
        {

            return View();
        }
        public ActionResult Contact()
        {

            return View();
        }
        public ActionResult Privacy()
        {

            return View();
        }
        public ActionResult Refund()
        {

            return View();
        }
        public ActionResult Disclaimer()
        {

            return View();
        }
        public ActionResult Deals()
        {

            return View();
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