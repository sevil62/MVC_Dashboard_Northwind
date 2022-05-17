using MVC_Dashboard_Northwind.CustomFilters;
using MVC_Dashboard_Northwind.Models;
using MVC_Dashboard_Northwind.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Dashboard_Northwind.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db=new NorthwindEntities();   

        // GET: Home
        public ActionResult About()
        {
            return View();
        }
        [AuthFilter]
        
        public ActionResult Index()
        {
            var totalproduct=db.Products.Count();
            ViewBag.Products = totalproduct;


            var employee = db.Employees.Count();
            ViewBag.Employees = employee;


            var order = db.Orders.Count();
            ViewBag.Orders = order;


            var customer = db.Customers.Count();
            ViewBag.Customers = customer;

           
            TempData["Orders"] = db.Orders.ToList();
            TempData.Keep();


            return View();
        }
        [AuthFilter]
        public ActionResult Details(int id)
        {
            var orderDetails=db.Order_Details.FirstOrDefault(x=>x.OrderID==id);
            return View(orderDetails);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                bool result = db.Employees.Any(x => x.FirstName == employeeVM.FirstName && x.LastName == employeeVM.LastName);
                if (result)
                {
                    Employee user = db.Employees.Where(x => x.FirstName == employeeVM.FirstName && x.LastName == employeeVM.LastName).FirstOrDefault();

                    Session["login"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "kullanıcı bilgileri hatalı!";
                    return View(employeeVM);
                }
            }
            else
            {
                return View(employeeVM);
            }

        }
    }
}