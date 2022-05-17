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
    public class CustomerController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Product
        public ActionResult Index()
        {
            var customer = db.Customers.ToList();
            ViewBag.Customers = customer;
            return View();
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCustomer(string id)
        {
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            Customer tobeUpdated = db.Customers.Find(customer.CustomerID);
            db.Entry(tobeUpdated).CurrentValues.SetValues(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}