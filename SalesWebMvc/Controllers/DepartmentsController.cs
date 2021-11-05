using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            var departments = new List<Department>()
            {
                new Department {Id = 1, Name = "Electronics"},
                new Department { Id = 2,Name = "Fashion"}
            };
            
           
            return View(departments);
        }
    }
}