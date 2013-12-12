using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.BusinessLogic
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository _repository;

        public EmployeeService()
        {
            _repository = new SessionEmployeeRepository();
        }

        public List<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        public Employee Create(Employee employee)
        {
            if (employee.Id == 0)
            {
                employee.Id = GetNextId();
            }
            return _repository.Create(employee);
        }

        public Employee Get(long id)
        {
            return _repository.Get(id);
        }

        public Employee Update(Employee product)
        {
            if (!_repository.Update(product))
            {
                throw new Exception("Product not found");
            }
            return product;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }


        public Employee CreateEmployee(string firstName, string lastName, double salary, long managerId)
        {
            return new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary,
                Manager = _repository.Get(managerId)
            };
        }        

        private long GetNextId()
        {
            return _repository.GetAll().Max(x => x.Id) + 1;
        }
    }
}