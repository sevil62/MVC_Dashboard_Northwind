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
    public class EmployeeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Product
        public ActionResult Index()
        {
            var employee = db.Employees.ToList();
            ViewBag.Employees = employee;
            return View();
        }
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            Employee tobeUpdated = db.Employees.Find(employee.EmployeeID);
            db.Entry(tobeUpdated).CurrentValues.SetValues(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}