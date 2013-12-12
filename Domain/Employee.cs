using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Employee
    {
        public Int64 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Double Salary { get; set; }
        public Employee Manager { get; set; }

        public String FullName { get { return String.Format("{0} {1}", FirstName, LastName); } }

    }
}