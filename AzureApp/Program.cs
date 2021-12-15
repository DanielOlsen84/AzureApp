using AzureApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureApp
{
    
    public class Program
    {
    //public static List<PersonModel> people;

        public static void Main(string[] args)
        {
            //DataAccess dataAccess = new DataAccess();
            //dataAccess.RecreateDatabase();
            //dataAccess.AddEmployee();

            //people = new List<PersonModel>();
            //DataAccess dataAccess = new DataAccess();

            //await dataAccess.AddEmployeeToDB(new EmployeeModel() { FirstName = "Danne", LastName = "Olsen", Salary = 370000 });
            //await dataAccess.AddEmployeeToDB(new EmployeeModel() { FirstName = "Sven", LastName = "Banan", Salary = 23000 });
            //await dataAccess.AddEmployeeToDB(new EmployeeModel() { FirstName = "Gunde", LastName = "Trast", Salary = 21000 });
            //await dataAccess.AddEmployeeToDB(new EmployeeModel() { FirstName = "Maja", LastName = "Gurka", Salary = -8000 });
            //await dataAccess.AddEmployeeToDB(new EmployeeModel() { FirstName = "Anders", LastName = "Flanders", Salary = 12000 });
            //await dataAccess.AddEmployeeToDB(new EmployeeModel() { FirstName = "Sur", LastName = "Citron", Salary = 63000 });
            //await dataAccess.AddEmployeeToDB(new EmployeeModel() { FirstName = "Lisa", LastName = "Sallad", Salary = 6000 });

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
