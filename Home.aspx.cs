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
            if(!IsPostBack)
            {
                FKLoader = new FKLoader();
                BindGridView();
            }
        }

        public void BindGridView()
        {
            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");
            string query = "SELECT * FROM Thesis";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
            FKLoader.UpdateGridView(GridView1);

            con.Close();
            dt.Dispose();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Submission.aspx");
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx");
        }
    }
}