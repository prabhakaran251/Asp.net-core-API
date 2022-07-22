using System;

namespace Telex.Models
{
    public class Logout
    {
        public string EmployeeEmailID { get; set; }
        public string Sessionkey { get; set; }
        public DateTime LoggedOutDateTime {get; set; }
    }
}
