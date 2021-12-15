using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureApp.Controllers
{
    public class HRController : Controller
    {
        //public async Task<IActionResult> Index()
        public IActionResult Index()
        {
            DataAccess dataAccess = new DataAccess();
            var employees = dataAccess.GetEmployees();
            return View("Index", employees);
        }

        //[HttpPost]
        public IActionResult AddEmployees(string firstName, string lastName, string salary)
        {

            DataAccess dataAccess = new DataAccess();
            int salaryInt = 0;
            int.TryParse(salary, out salaryInt);

            dataAccess.AddEmployee(firstName, lastName, salaryInt);
            var employees = dataAccess.GetEmployees();
            return View("Index", employees);
        }

        //public string AddEmployees(string fName)
        //{

        //    DataAccess dataAccess = new DataAccess();

        //    dataAccess.AddEmployee(fName, fName, 79);
        //    var employees = dataAccess.GetEmployees();
        //    return "Hi " + fName;
        //}

    }
}
