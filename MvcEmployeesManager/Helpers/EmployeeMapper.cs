using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using Domain.BusinessLogic;
using MvcEmployeesManager.Models;

namespace MvcEmployeesManager.Helpers
{
    public static class EmployeeMapper
    {
        public static EmployeesListModel MapEmployeeListModel(this Employee employee)
        {
            return new EmployeesListModel
            {
                Id = employee.Id,
                Name = employee.FullName,
                Salary = employee.Salary,
                ManagerName = employee.Manager != null ? employee.Manager.FullName : ""
            };
        }

        public static EmployeeModel MapToEmployeeModel(this Employee employee)
        {
            return new EmployeeModel
            {
                Id = employee.Id,
                FirsName = employee.FirstName,
                LastName = employee.LastName,
                Salary = employee.Salary,
                ManagerId = employee.Manager != null ? employee.Manager.Id : 0
            };
        }

        public static Employee CreateEmployee(EmployeeModel model)
        {
            return new Employee
            {
                Id = model.Id,
                FirstName = model.FirsName,
                LastName = model.LastName,
                Salary = model.Salary,
                Manager = (new EmployeeService()).Get(model.ManagerId)
            };
        }

        public static Employee MapFromEmployeeModel(EmployeeModel model)
        {
            var service = new EmployeeService();
            var employee = service.Get(model.Id);

            employee.Id = model.Id;
            employee.FirstName = model.FirsName;
            employee.LastName = model.LastName;
            employee.Salary = model.Salary;
            employee.Manager = service.Get(model.ManagerId);

            return employee;
        }
    }
}