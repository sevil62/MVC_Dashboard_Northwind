using MVC_Dashboard_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Dashboard_Northwind.CustomFilters
{
   
    public class AcFilter:FilterAttribute,IActionFilter
    {
        NorthwindEntities db = new NorthwindEntities();

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Employee employee=new Employee();
            employee.FirstName = filterContext.ActionDescriptor.ActionName;
            employee.LastName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            db.Employees.Add(employee);
            db.SaveChanges();
           
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Employee employee = new Employee();
            employee.FirstName = filterContext.ActionDescriptor.ActionName;
            employee.LastName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            db.Employees.Add(employee);
            db.SaveChanges();
        }
    }
}