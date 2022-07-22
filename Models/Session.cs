using System;
using System.Linq;

namespace Telex.Models
{
    public class Session
    {
        public string EmployeeEmailID { get; set; }
        public int EmployeeID { get; set; }

        public string Sessionkey = KEY();
        public DateTime LoggedInDateTime { get; set; }
        public int CreatedBY { get; set; }
        public DateTime CreatedDate { get; set; }

        public int ModifiedBY { get; set; }
        public DateTime ModifiedDate { get; set; }



        private  static string KEY()
        {
            Random ran = new Random();

            String b = "abcdefghijklmnopqrstuvwxyz0123456789";
            String sc = "!@#$%^&*~";

            int length = 6;

            String random = "";

            for (int i = 0; i < length; i++)
            {
                int a = ran.Next(b.Length);
                random = random + b.ElementAt(a);
            }
            for (int j = 0; j < 2; j++)
            {
                int sz = ran.Next(sc.Length);
                random = random + sc.ElementAt(sz);
            }

            return random;

        }



    }
}
