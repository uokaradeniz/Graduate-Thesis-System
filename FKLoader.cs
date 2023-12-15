using System;
using System.Collections.Generic;
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
        public Dictionary<int, string> type = new Dictionary<int, string>();
        public Dictionary<int, string> university = new Dictionary<int, string>();

        public void UpdateGridView(GridView GridView)
        {
            //load all foreignkey values to dictionaries to show them in gridview later
            LoadUniversityForeignKeyValues();
            LoadAuthorForeignKeyValues();
            LoadInstituteForeignKeyValues();
            LoadSupervisorForeignKeyValues();
            LoadTypeForeignKeyValues();

            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                GridView.Rows[i].Cells[3].Text = author[Int32.Parse(GridView.Rows[i].Cells[3].Text)];
                GridView.Rows[i].Cells[5].Text = type[Int32.Parse(GridView.Rows[i].Cells[5].Text)];
                GridView.Rows[i].Cells[6].Text = university[Int32.Parse(GridView.Rows[i].Cells[6].Text)];
                GridView.Rows[i].Cells[7].Text = institute[Int32.Parse(GridView.Rows[i].Cells[7].Text)];
                GridView.Rows[i].Cells[8].Text = supervisor[Int32.Parse(GridView.Rows[i].Cells[8].Text)];
                //Cosupervisor sonra bak
                //GridView.Rows[i].Cells[9].Text = supervisor[Int32.Parse(GridView.Rows[i].Cells[8].Text)];
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
                author.Add(Convert.ToInt32(reader["AUTHOR_ID"]), reader["FIRST_NAME"].ToString() + " " + reader["LAST_NAME"].ToString());
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