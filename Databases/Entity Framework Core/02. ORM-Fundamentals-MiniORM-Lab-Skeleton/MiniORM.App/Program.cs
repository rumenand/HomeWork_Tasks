
namespace MiniORM.App
{
    using System;
    using Data;
    using Data.Entities;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            var connectionString = @"Server=localhost\SQLEXPRESS01;Database=MiniORM;Trusted_Connection=True;";
            var context = new SoftUniDbContext(connectionString);
            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true,
            }); ;
            var employee = context.Employees.Last();
            employee.FirstName = "Modified";
            //context.SaveChanges();
            Console.WriteLine(string.Join(", ",context.Employees.Select(x=>x.FirstName).ToList()));
        }
    }
}
