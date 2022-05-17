using MVC_Dashboard_Northwind.CustomFilters;
using MVC_Dashboard_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Dashboard_Northwind.Controllers
{
    [AuthFilter]
    [AcFilter]
    public class OrderController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Product
        public ActionResult Index()
        {
            var order = db.Orders.ToList();
            ViewBag.Orders = order;
            return View();
        }
        public ActionResult AddOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateOrder(int id)
        {
            Order order = db.Orders.Find(id);
            return View(order);
        }
        [HttpPost]
        public ActionResult UpdateOrder(Order order)
        {
            Order tobeUpdated = db.Orders.Find(order.OrderID);
            db.Entry(tobeUpdated).CurrentValues.SetValues(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}