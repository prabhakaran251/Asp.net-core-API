using Microsoft.VisualBasic;
using System;

namespace Telex.Models
{
    public class Getall
    {
        public int EmployeeID { get; set; }
        public string EmployeeEmailID { get; set; }
        public string EmployeePassword { get; set; }
        public int EmployeeDepartmentID { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeCity { get; set; }
        public string Status { get; set; }
        public int CreatedBY { get; set; }
        public string EmployeeRole { get; set; }
        public int EmployeeSalary { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBY { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
