using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercise1
{
    public partial class Default : System.Web.UI.Page
    {
        private const string TITLE = "title";

        public string PageTitle 
        {
            get
            {
                return ViewState[TITLE] == null ? "" : ViewState[TITLE].ToString();
            }
            set
            {
                ViewState[TITLE] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangeLabelText_Click(object sender, EventArgs e)
        {
            //lblDemo.Text = Request.Form["txtNewLabelText"];
            lblDemo.Text = txtNewLabelText.Text;
        }

        protected void btnChangePageTitle_Click(object sender, EventArgs e)
        {
            PageTitle = "This is a new title";
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            Page.Title = PageTitle;
        }

        protected void chbToogleControlsVisibility_CheckedChanged(object sender, EventArgs e)
        {
            pnlGroupControls.Visible = chbToogleControlsVisibility.Checked;
        }

        protected void ddlDemo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDemo.Text = ddlDemo.SelectedItem.Text;
        }

        protected void btnRedirectToPageFlow_Click(object sender, EventArgs e)
        {
            // ~ means root of the site
            Response.Redirect("~/PageFlow.aspx");
        }

        protected void lnkRedirectToPageFlow_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PageFlow.aspx");
        }
    }
}