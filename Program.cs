using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public string Name { get; set; } = "";
    public string Department { get; set; } = "";
    public double Salary { get; set; }
}

class Program
{
    static void Main()
    {
        // Create a list of employees
        List<Employee> employees =
        [
            new Employee
            {
                Name = "Ravi",
                Department = "IT",
                Salary = 60000
            },

            new Employee
            {
                Name = "Kiran",
                Department = "IT",
                Salary = 70000
            },

            new Employee
            {
                Name = "Rahul",
                Department = "HR",
                Salary = 45000
            },

            new Employee
            {
                Name = "Suresh",
                Department = "HR",
                Salary = 55000
            },

            new Employee
            {
                Name = "Arjun",
                Department = "Finance",
                Salary = 75000
            },

            new Employee
            {
                Name = "Vijay",
                Department = "Finance",
                Salary = 85000
            },

            new Employee
            {
                Name = "Anil",
                Department = "Sales",
                Salary = 40000
            },

            new Employee
            {
                Name = "Ramesh",
                Department = "Sales",
                Salary = 45000
            }
        ];

        // LINQ chain
        var result = employees
            .GroupBy(e => e.Department)
            .Select(group => new
            {
                Department = group.Key,
                AverageSalary = group.Average(e => e.Salary)
            })
            .Where(group => group.AverageSalary > 50000)
            .OrderByDescending(group => group.AverageSalary)
            .ToList();

        // Display the result
        foreach (var department in result)
        {
            Console.WriteLine(
                $"{department.Department} - Average Salary: {department.AverageSalary:C}"
            );
        }
    }
}