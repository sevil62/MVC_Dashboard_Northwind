using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Dashboard_Northwind.VMClasses
{
    public class EmployeeVM
    {
        [Required(ErrorMessage ="Kullanıcı adı boş geçilmez")]
        [Display(Name ="İsim")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Kullanıcı soyad boş geçilmez")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

    }
}