using System;
using System.Collections.Generic;
using System.Text;

namespace SampleWebApplication.Data.Entities
{
    public class Employee
    {
        public int? ID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public EmployeePosition Position { get; set; }
        public int PositionID { get; set; }
    }
}
