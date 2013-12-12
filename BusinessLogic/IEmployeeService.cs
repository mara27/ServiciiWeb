using System;
using System.Collections.Generic;
using Domain;

namespace Domain.BusinessLogic
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Employee Create(Employee employee);        
        Employee Get(Int64 id);
        Employee Update(Employee employee);
        void Delete(Int64 id);
        Employee CreateEmployee(string firstName, string lastName, Double salary, Int64 managerId);
    }
}
