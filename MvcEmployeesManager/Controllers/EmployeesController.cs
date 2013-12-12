using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.BusinessLogic;
using MvcEmployeesManager.Models;
using Domain.Helpers;
using MvcEmployeesManager.Helpers;

namespace MvcEmployeesManager.Controllers
{
    public class EmployeesController : Controller
    {
        public EmployeeService Service { get; set; }

        public EmployeesController()
        {
            Service = new EmployeeService();
        }

        public ActionResult Index()
        {
            var employeesModelList = Service.GetAll().Select(emp => emp.MapEmployeeListModel());
            return View(employeesModelList);
        }

        public ActionResult Details(int id)
        {
            var employee = Service.GetAll().FirstOrDefault(emp => emp.Id == id);
            if (employee == null)
            {
                return View(new EmployeeModel());
            }
            return View(employee.MapToEmployeeModel());
        }

        public ActionResult Create()
        {
            return View(new EmployeeModel());
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            try
            {
                var employee = EmployeeMapper.CreateEmployee(employeeModel);
                Service.Create(employee);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(new EmployeeModel());
            }
        }

        public ActionResult Edit(long id)
        {
            var employee = Service.Get(id);

            return View(employee.MapToEmployeeModel());
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel employeeModel)
        {
            try
            {
                var employee = EmployeeMapper.MapFromEmployeeModel(employeeModel);
                Service.Update(employee);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Delete(long id)
        {
            try
            {

                Service.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
