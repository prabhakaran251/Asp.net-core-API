using Microsoft.VisualBasic;
using System;

namespace Telex.Models
{
    public class GetID
    {
        public int DepartmentID { get; set; }
        public int EmployeeID { get; set; }

        public string DepartmentName { get; set; }
        public string Status { get; set; }

        public int CreatedBY { get; set; }
        public DateTime CreatedDate { get; set; }

        public int ModifiedBY { get; set; }
        public DateTime ModifiedDate { get; set; }



    }
}


