using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureApp.Controllers
{
    
    
    public class PeopleController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePerson()
        {
            return View();
        }

        //[Route("People/ListPeople/{name}")]
        //[HttpPost]
        public IActionResult ListPeople(string name)
        {
            List<PersonModel> people = new List<PersonModel>();

            people.Add(new PersonModel { Name = name});
            //people.Add(new PersonModel { Name = "Danne 2" });
            //people.Add(new PersonModel { Name = "Danne 3" });

            return View(people);
        }
    }
}
