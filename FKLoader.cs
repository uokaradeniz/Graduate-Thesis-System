using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Graduate_Thesis_System
{
    public class FKLoader
    {
        public Dictionary<int, string> author = new Dictionary<int, string>();
        public Dictionary<int, string> institute = new Dictionary<int, string>();
        public Dictionary<int, string> supervisor = new Dictionary<int, string>();
        public Dictionary<int, string> cosupervisor = new Dictionary<int, string>();
        public Dictionary<int, string> type = new Dictionary<int, string>();
        public Dictionary<int, string> university = new Dictionary<int, string>();

        public void BindGridView(GridView gridView)
        {
            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");

            string query = "SELECT * FROM Thesis";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            gridView.DataSource = dt;
            gridView.DataBind();
            UpdateGridView(gridView);

            con.Close();
            dt.Dispose();
        }
        public void BindGridView(GridView gridView, DropDownList selectionDropDownList)
        {
            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");
            string query = "";

            if (selectionDropDownList.SelectedValue == "THESIS_NO")
                query = "SELECT * FROM Thesis";
            else if (selectionDropDownList.SelectedValue == "AUTHOR")
                query = "SELECT * FROM Author";
            else if (selectionDropDownList.SelectedValue == "TYPE")
                query = "SELECT * FROM Type";
            else if (selectionDropDownList.SelectedValue == "UNIVERSITY")
                query = "SELECT * FROM University";
            else if (selectionDropDownList.SelectedValue == "INSTITUTE")
                query = "SELECT * FROM Institute";
            else if (selectionDropDownList.SelectedValue == "SUPERVISOR")
                query = "SELECT * FROM Supervisor";


            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            gridView.DataSource = dt;
            gridView.DataBind();

            con.Close();
            dt.Dispose();
        }

        public void UpdateGridView(GridView GridView)
        {
            //load all foreignkey values to dictionaries to show them in gridview later
            LoadUniversityForeignKeyValues();
            LoadAuthorForeignKeyValues();
            LoadInstituteForeignKeyValues();
            LoadSupervisorForeignKeyValues();
            LoadCosupervisorForeignKeyValues();
            LoadTypeForeignKeyValues();

            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                GridView.Rows[i].Cells[3].Text = author[Int32.Parse(GridView.Rows[i].Cells[3].Text)];
                GridView.Rows[i].Cells[5].Text = type[Int32.Parse(GridView.Rows[i].Cells[5].Text)];
                GridView.Rows[i].Cells[6].Text = university[Int32.Parse(GridView.Rows[i].Cells[6].Text)];
                GridView.Rows[i].Cells[7].Text = institute[Int32.Parse(GridView.Rows[i].Cells[7].Text)];
                GridView.Rows[i].Cells[8].Text = supervisor[Int32.Parse(GridView.Rows[i].Cells[8].Text)];
                try
                {
                    GridView.Rows[i].Cells[9].Text = cosupervisor[Int32.Parse(GridView.Rows[i].Cells[9].Text)];
                }
                catch
                {
                    GridView.Rows[i].Cells[9].Text = "None";

                }
            }
        }
        public void LoadAuthorForeignKeyValues()
        {
            SqlConnection conn = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT AUTHOR_ID, FIRST_NAME, LAST_NAME FROM Author", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                author.Add((int)reader["AUTHOR_ID"], reader["FIRST_NAME"].ToString() + " " + reader["LAST_NAME"].ToString());
            }
            conn.Close();
        }
        public void LoadInstituteForeignKeyValues()
        {
            SqlConnection conn = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT INSTITUTE_ID, NAME FROM Institute", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                institute.Add((int)reader["INSTITUTE_ID"], reader["NAME"].ToString());
            }
            conn.Close();

        }
        public void LoadSupervisorForeignKeyValues()
        {
            SqlConnection conn = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUPERVISOR_ID, FIRST_NAME, LAST_NAME FROM Supervisor", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                supervisor.Add((int)reader["SUPERVISOR_ID"], reader["FIRST_NAME"].ToString() + " " + reader["LAST_NAME"].ToString());
            }
            conn.Close();

        }
        public void LoadCosupervisorForeignKeyValues()
        {
            SqlConnection conn = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUPERVISOR_ID, FIRST_NAME, LAST_NAME FROM Supervisor WHERE IS_CO_SUPERVISOR = 1", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cosupervisor.Add((int)reader["SUPERVISOR_ID"], reader["FIRST_NAME"].ToString() + " " + reader["LAST_NAME"].ToString());
            }
            conn.Close();

        }
        public void LoadTypeForeignKeyValues()
        {
            SqlConnection conn = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TYPE_ID, TYPE_NAME FROM Type", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                type.Add((int)reader["TYPE_ID"], reader["TYPE_NAME"].ToString());
            }
            conn.Close();

        }
        public void LoadUniversityForeignKeyValues()
        {
            SqlConnection conn = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT UNIVERSITY_ID, NAME FROM University", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                university.Add((int)reader["UNIVERSITY_ID"], reader["NAME"].ToString());
            }
            conn.Close();

        }

    }
}