using System;
using System.Collections.Generic;
using Domain;

namespace Domain.BusinessLogic
{
    public interface IRepository
    {
        List<Employee> GetAll();
        Employee Create(Employee employee);
        Employee Get(Int64 id);
        bool Update(Employee employee);
        void Delete(Int64 id);
    }
}
