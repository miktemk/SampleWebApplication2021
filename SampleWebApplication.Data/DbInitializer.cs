using Microsoft.EntityFrameworkCore;
using SampleWebApplication.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleWebApplication.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.EmployeePositions.Any())
            {
                var positions = new EmployeePosition[]
                {
                    new EmployeePosition { Title = "Project Manager" },
                    new EmployeePosition { Title = "Production Manager" },
                    new EmployeePosition { Title = "General Manager" },
                    new EmployeePosition { Title = "HR Director" },
                    new EmployeePosition { Title = "Senior Editor" },
                    new EmployeePosition { Title = "Editor" },
                };

                foreach (var p in positions)
                {
                    context.EmployeePositions.Add(p);
                }

                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                var employees = new Employee[]
                {
                    new Employee { PositionID=1, Address="308 Negra Arroyo Lane, Albuquerque, New Mexico", PhoneNumber="123-456-7890", FullName="John Doe" },
                    new Employee { PositionID=2, Address="308 Negra Arroyo Lane, Albuquerque, New Mexico", PhoneNumber="123-456-7890", FullName="Roger Flynn" },
                    new Employee { PositionID=3, Address="308 Negra Arroyo Lane, Albuquerque, New Mexico", PhoneNumber="123-456-7890", FullName="Alex Virasamy" },
                    new Employee { PositionID=4, Address="308 Negra Arroyo Lane, Albuquerque, New Mexico", PhoneNumber="123-456-7890", FullName="Kyle Pitt" },
                    new Employee { PositionID=5, Address="308 Negra Arroyo Lane, Albuquerque, New Mexico", PhoneNumber="123-456-7890", FullName="Elizabeth James" },
                    new Employee { PositionID=6, Address="308 Negra Arroyo Lane, Albuquerque, New Mexico", PhoneNumber="123-456-7890", FullName="Shelly Bell" },
                    new Employee { PositionID=6, Address="308 Negra Arroyo Lane, Albuquerque, New Mexico", PhoneNumber="123-456-7890", FullName="Martin Ziberman" },
                };

                foreach (var e in employees)
                {
                    context.Employees.Add(e);
                }

                context.SaveChanges();
            }

        }
    }
}
