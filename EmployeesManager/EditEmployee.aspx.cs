using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.BusinessLogic;
using Domain;

namespace EmployeesManager
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        private const String QueryStringId = "id";

        private IEmployeeService _employeeService = new EmployeeService();

        private Int64 EditedEmployeeId
        {
            get
            {
                var idAsString = Request[QueryStringId];
                Int64 id;
                if (Int64.TryParse(idAsString, out id))
                {
                    return id;
                }

                return 0;
            }
        }

        private bool IsEdit
        {
            get { return EditedEmployeeId != 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateManagersDropDown();
                var employee = GetEditedEmployee();
                PopulateView(employee);
            }
        }

        private void PopulateView(Employee employee)
        {
            hdnId.Value = employee.Id.ToString();
            txtFirstName.Text = employee.FirstName;
            txtLastName.Text = employee.LastName;
            txtSalary.Text = employee.Salary.ToString("F", CultureInfo.CurrentCulture);
            if (IsEdit && employee.Manager != null)
            {
                ddlManagers.SelectedValue = employee.Manager.Id.ToString();
            }
        }

        private Employee GetEditedEmployee()
        {
            return IsEdit ? _employeeService.Get(EditedEmployeeId) : new Employee();
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            var employee = GetFromView();
            _employeeService.Create(employee);
            ReturnToListPage();
        }

        private Employee GetFromView()
        {
            var firstName = txtFirstName.Text;
            var lastName = txtLastName.Text;
            var salary = Double.Parse(txtSalary.Text, NumberStyles.Number, CultureInfo.CurrentCulture);
            var managerId = Int64.Parse(ddlManagers.SelectedValue);
            var id = Int64.Parse(hdnId.Value);

            var employee = _employeeService.CreateEmployee(firstName, lastName, salary, managerId);
            employee.Id = id;

            return employee;
        }

        protected void PopulateManagersDropDown()
        {
            var employees = _employeeService.GetAll();
            if (IsEdit)
            {
                employees = employees.Where(x => x.Id != EditedEmployeeId).OrderBy(x => x.FirstName).ToList();
            }
            
            ddlManagers.DataSource = employees;
            ddlManagers.DataBind();         
        }


        private void ReturnToListPage()
        {
            Response.Redirect("~/EmployeesList.aspx");
        }
    }
}