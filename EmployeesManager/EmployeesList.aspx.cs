using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.BusinessLogic;
using Domain.Helpers;

namespace EmployeesManager
{
    public partial class EmployeesList : System.Web.UI.Page
    {
        private IEmployeeService _employeeService = new EmployeeService();
        
        protected void Page_Load(object sender, EventArgs e)        
        {   
            if (!Page.IsPostBack)
            {
                BindGridView();
            }
        }        
        
        private void BindGridView()
        {
            gvEmployees.DataSource = _employeeService.GetAll();
            gvEmployees.DataBind();
        }

        protected void OnEditClick(object sender, GridViewEditEventArgs e)
        {
            var dataKey = gvEmployees.DataKeys[e.NewEditIndex];
            if (dataKey != null)
            {
                var key = dataKey.Value.ToString();
                Response.Redirect(String.Format("~/EditEmployee.aspx?id={0}", key));
            }
            CancelEditAction(e);
        }

        protected void OnDeleteClick(object sender, GridViewDeleteEventArgs e)
        {
            var dataKey = gvEmployees.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                var key = dataKey.Value.ToString();
                var id = Int64.Parse(key);
                _employeeService.Delete(id);
            }
            CancelEditAction(e);
            BindGridView();
        }

        private void CancelEditAction(CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}