using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEmployeesManager.Models
{
    public class EmployeesListModel
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public Double Salary { get; set; }
        public String ManagerName { get; set; }
    }
}