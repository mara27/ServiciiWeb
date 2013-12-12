using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Helpers;
using Domain;

namespace Domain.BusinessLogic
{
    public class SessionEmployeeRepository : IRepository
    {
        //private const String SESSION_KEY = "EMPLOYEE_LIST";

        //private List<Employee> Employees
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session[SESSION_KEY] == null)
        //        {
        //            HttpContext.Current.Session[SESSION_KEY] = EmployeesHelper.ConstructEmployeesList();
        //        }
        //        return (HttpContext.Current.Session[SESSION_KEY] as List<Employee>);
        //    }

        //    set
        //    {
        //        HttpContext.Current.Session[SESSION_KEY] = value;
        //    }
        //}

        private static List<Employee> Employees = EmployeesHelper.ConstructEmployeesList();

        public List<Employee> GetAll()
        {
            return Employees;
        }

        public Employee Get(long id)
        {
            return Employees.FirstOrDefault(x => x.Id == id);
        }

        public Employee Create(Employee employee)
        {
            Employees.Add(employee);
            return employee;
        }

        public bool Update(Employee item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = Employees.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            Employees.RemoveAt(index);
            Employees.Add(item);
            return true;
        } 

        public void Delete(long id)
        {
            Employees.RemoveAll(p => p.Id == id);
        }       
    }
}