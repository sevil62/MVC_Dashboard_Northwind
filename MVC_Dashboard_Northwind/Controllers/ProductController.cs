using MVC_Dashboard_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Dashboard_Northwind.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Product
        public ActionResult Index()
        {
            var totalproduct = db.Products.ToList();
            ViewBag.Products = totalproduct;
            return View();
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateProduct(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            Product tobeUpdated=db.Products.Find(product.ProductID);
            db.Entry(tobeUpdated).CurrentValues.SetValues(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
         public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}