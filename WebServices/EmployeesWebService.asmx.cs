using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Domain;
using Domain.Helpers;
using Domain.BusinessLogic;

namespace WebServices
{
    /// <summary>
    /// Summary description for EmployeesWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeesWebService : System.Web.Services.WebService
    {
        EmployeeService es = new EmployeeService();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<Employee> GetAll()
        {
            return es.GetAll();
        }

        [WebMethod]
        public Employee Get(long id)
        {
            return es.Get(id);
        }

        [WebMethod]
        public Employee Create(string firstname, string lastname, double salary)
        {
            Employee employee = new Employee();
            employee.FirstName = firstname;
            employee.LastName = lastname;
            employee.Salary = salary;
            return es.Create(employee);
        }

        [WebMethod]
        public Employee Update(Employee employee)
        {
            return es.Update(employee);
        }

        [WebMethod]
        public void Delete(long id)
        {
            es.Delete(id);
        }
    }
}
