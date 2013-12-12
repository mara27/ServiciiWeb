using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using Domain.BusinessLogic;

namespace MvcEmployeesManager.Models
{
    public class EmployeeModel
    {
        public Int64 Id { get; set; }
        public String FirsName { get; set; }
        public String LastName { get; set; }
        public Double Salary { get; set; }
        public Int64 ManagerId { get; set; }

        public String FullName { get { return String.Format("{0} {1}", FirsName, LastName); } }

        public List<Employee> PossibleManagers 
        {
            get
            {
                var list = (new EmployeeService()).GetAll().Where(emp => emp.Id != Id).ToList<Employee>();
                list.Insert(0, new Employee());
                return list;
            }            
        }
    }
}