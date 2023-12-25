using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Graduate_Thesis_System
{
    public partial class Home : System.Web.UI.Page
    {
        FKLoader FKLoader;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FKLoader = new FKLoader();
                FKLoader.BindGridView(GridView1);
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Submission.aspx");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx");
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void EditDeleteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx");
        }
    }
}