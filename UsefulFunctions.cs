using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Graduate_Thesis_System
{
    public class UsefulFunctions
    {
        public void FillTypeList(DropDownList dropDownList)
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");

            string query = "SELECT TYPE_ID, TYPE_NAME FROM Type";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            da.Fill(ds);

            dropDownList.DataSource = ds;
            dropDownList.DataTextField = "TYPE_NAME";
            dropDownList.DataValueField = "TYPE_ID";
            dropDownList.DataBind();

            con.Close();
            da.Dispose();

        }
        public void FillInstituteList(DropDownList dropDownList)
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");

            string query = "SELECT INSTITUTE_ID, NAME FROM Institute";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            da.Fill(ds);

            dropDownList.DataSource = ds;
            dropDownList.DataTextField = "NAME";
            dropDownList.DataValueField = "INSTITUTE_ID";
            dropDownList.DataBind();

            con.Close();
            da.Dispose();

        }
        public void FillAuthorList(DropDownList dropDownList)
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");

            string query = "SELECT AUTHOR_ID, FIRST_NAME + ' ' + LAST_NAME AS FULL_NAME FROM Author";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            da.Fill(ds);

            dropDownList.DataSource = ds;
            dropDownList.DataTextField = "FULL_NAME";
            dropDownList.DataValueField = "AUTHOR_ID";
            dropDownList.DataBind();

            con.Close();
            da.Dispose();

        }
        public void FillUniversityList(DropDownList dropDownList)
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");

            string query = "SELECT UNIVERSITY_ID, NAME FROM University";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            da.Fill(ds);

            dropDownList.DataSource = ds;
            dropDownList.DataTextField = "NAME";
            dropDownList.DataValueField = "UNIVERSITY_ID";
            dropDownList.DataBind();

            con.Close();
            da.Dispose();

        }
        public void FillSupervisorList(DropDownList dropDownList)
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");

            string query = "SELECT SUPERVISOR_ID, FIRST_NAME + ' ' + LAST_NAME AS FULL_NAME FROM Supervisor";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            da.Fill(ds);

            dropDownList.DataSource = ds;
            dropDownList.DataTextField = "FULL_NAME";
            dropDownList.DataValueField = "SUPERVISOR_ID";
            dropDownList.DataBind();

            con.Close();
            da.Dispose();

        }
        public void FillCosupervisorList(DropDownList dropDownList)
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");

            string query = "SELECT SUPERVISOR_ID, FIRST_NAME + ' ' + LAST_NAME AS FULL_NAME FROM Supervisor WHERE IS_CO_SUPERVISOR = 1";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            da.Fill(ds);

            dropDownList.DataSource = ds;
            dropDownList.DataTextField = "FULL_NAME";
            dropDownList.DataValueField = "SUPERVISOR_ID";
            dropDownList.DataBind();

            con.Close();
            da.Dispose();

        }
        public void FillTopicList(DropDownList dropDownList)
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");

            string query = "SELECT TOPIC_NAME FROM Subject_Topic";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            da.Fill(ds);

            dropDownList.DataSource = ds;
            dropDownList.DataValueField = "TOPIC_NAME";
            dropDownList.DataBind();

            con.Close();
            da.Dispose();

        }
        public void FillKeywordList(DropDownList dropDownList)
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");

            string query = "SELECT KEYWORD_NAME FROM Keyword";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            da.Fill(ds);

            dropDownList.DataSource = ds;
            dropDownList.DataValueField = "KEYWORD_NAME";
            dropDownList.DataBind();

            con.Close();
            da.Dispose();

        }
        public void FillLanguageList(DropDownList dropDownList)
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");

            string query = "SELECT LANGUAGE_NAME FROM Language";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            da.Fill(ds);

            dropDownList.DataSource = ds;
            dropDownList.DataValueField = "LANGUAGE_NAME";
            dropDownList.DataBind();

            con.Close();
            da.Dispose();

        }
        public void FillThesisDDL(DropDownList dropDownList)
        {
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
        public void FillOnlyFKThesisDDL(DropDownList dropDownList)
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");
            con.Open();
            string query = $"SELECT TOP 0 THESIS_NO, AUTHOR, TYPE, UNIVERSITY, INSTITUTE, SUPERVISOR FROM Thesis";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            for (int i = 0; i< reader.FieldCount; i++)
            {
                ListItem item = new ListItem(reader.GetName(i));
                dropDownList.Items.Add(item);
            }

            con.Close();
        }


    }

}