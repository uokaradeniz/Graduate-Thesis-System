using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Graduate_Thesis_System
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillSearchDDL(SearchDropDownList);
        }

        void FillSearchDDL(DropDownList dropDownList)
        {
            ListItem all = new ListItem("All");
            dropDownList.Items.Add(all);

            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");
            con.Open();
            string query = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Thesis'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListItem item = new ListItem(reader["COLUMN_NAME"].ToString());
                dropDownList.Items.Add(item);
            }

            con.Close();
        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");
            string searchWord = SearchTextBox.Text;
            con.Open();
            if (SearchDropDownList.SelectedItem.Text == "All")
            {
                //search in all columns
                SqlCommand cmd = new SqlCommand("GetThesisByWord", con);
                //search is done by using stored procedure in sql server
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Word", searchWord);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;
            }
            else
            {
                //search by one column
                string query = $"SELECT * FROM Thesis WHERE {SearchDropDownList.SelectedItem.Text} LIKE '%' + @Word + '%'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Word", searchWord);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;
            }
            GridView1.DataBind();
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}