using AzureApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace AzureApp
{
    public class DataAccess
    {
        Context context = new Context();

        public void RecreateDatabase()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        //public void AddEmployee()
        //{
        //    EmployeeModel employee = new EmployeeModel() { FirstName = "Daniel", LastName = "Olsen", Salary = 666 };
        //    EmployeeModel employee2 = new EmployeeModel() { FirstName = "Lasse", LastName = "Gurka", Salary = 37800 };
        //    EmployeeModel employee3 = new EmployeeModel() { FirstName = "Anna", LastName = "Banjo", Salary = 22100 };
        //    context.Employees.Add(employee);
        //    context.Employees.Add(employee2);
        //    context.Employees.Add(employee3);
            
        //    context.SaveChanges();

        //}

        public void AddEmployee(string firstName, string lastName, int salary)
        {
            EmployeeModel employee = new EmployeeModel() { FirstName = firstName, LastName = lastName, Salary = salary };
            
            context.Employees.Add(employee);
            
            context.SaveChanges();

        }

        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> result = context.Employees.ToList();
            return result;
        }
    }
}
