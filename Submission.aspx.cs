using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Collections;
using System.Runtime.Remoting.Messaging;

namespace Graduate_Thesis_System
{
    public partial class Submission : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillTypeList();
                FillInstituteList();
                FillTopicList();
                FillKeywordList();
                FillLanguageList();
            }
        }
    
        void FillTypeList()
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");

            string query = "SELECT TYPE_ID, TYPE_NAME FROM Type";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            da.Fill(ds);

            DropDownList3.DataSource = ds;
            DropDownList3.DataTextField = "TYPE_NAME";
            DropDownList3.DataValueField = "TYPE_ID";
            DropDownList3.DataBind();

            con.Close();
            da.Dispose();

        }
        void FillInstituteList()
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");

            string query = "SELECT INSTITUTE_ID, NAME FROM Institute";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            da.Fill(ds);

            DropDownList4.DataSource = ds;
            DropDownList4.DataTextField = "NAME";
            DropDownList4.DataValueField = "INSTITUTE_ID";
            DropDownList4.DataBind();

            con.Close();
            da.Dispose();

        }
        void FillTopicList()
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");

            string query = "SELECT TOPIC_NAME FROM Subject_Topic";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            da.Fill(ds);

            DropDownList1.DataSource = ds;
            DropDownList1.DataValueField = "TOPIC_NAME";
            DropDownList1.DataBind();

            con.Close();
            da.Dispose();

        }
        void FillKeywordList()
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");

            string query = "SELECT KEYWORD_NAME FROM Keyword";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            da.Fill(ds);

            DropDownList2.DataSource = ds;
            DropDownList2.DataValueField = "KEYWORD_NAME";
            DropDownList2.DataBind();

            con.Close();
            da.Dispose();

        }

        void FillLanguageList()
        {
            SqlConnection con = new SqlConnection("Data Source = UGUROGUZHANPC; Initial Catalog = GraduateThesisSystem; Integrated Security = True;");

            string query = "SELECT LANGUAGE_NAME FROM Language";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            da.Fill(ds);

            DropDownList5.DataSource = ds;
            DropDownList5.DataValueField = "LANGUAGE_NAME";
            DropDownList5.DataBind();

            con.Close();
            da.Dispose();

        }

        int ReturnLastIdentity(SqlCommand command)
        {
            int lastIdentity = 0;
            object result = command.ExecuteScalar();
            if (result != null)
            {
                lastIdentity = Convert.ToInt32(result);
                return lastIdentity;
            }
            return -1;
        }

        protected void Submit_button_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");
            try
            {
                con.Open();

                SqlCommand com = new SqlCommand();

                com.Connection = con;
                //author
                com.CommandText = "SELECT IDENT_CURRENT('Author') AS LastIdentity";
                int authorIdentity = ReturnLastIdentity(com);

                com.CommandText = "INSERT INTO Author (FIRST_NAME, LAST_NAME) VALUES ('" + Firstname_textbox.Text + "','" + Lastname_textbox.Text + "')";
                com.ExecuteNonQuery();

                //university
                com.CommandText = "SELECT IDENT_CURRENT('University') AS LastIdentity";
                int universityIdentity = ReturnLastIdentity(com);

                com.CommandText = "INSERT INTO University (NAME, INSTITUTE) VALUES ('" + University_textbox.Text + "','" +DropDownList4.SelectedValue+ "')";
                com.ExecuteNonQuery();

                //supervisor
                com.CommandText = "SELECT IDENT_CURRENT('Supervisor') AS LastIdentity";
                int supervisorIdentity = ReturnLastIdentity(com);

                bool hasCoSupervisor = false;
                if(Cosupervisor_textbox.Text != null)
                {
                    hasCoSupervisor = true;
                } else
                {
                    hasCoSupervisor = false;
                }
                com.CommandText = "INSERT INTO Supervisor (FIRST_NAME, LAST_NAME, IS_CO_SUPERVISOR) VALUES ('" + SupervisorFname_textbox.Text + "','" + SupervisorLname_textbox.Text + "', '" + hasCoSupervisor + "')";
                com.ExecuteNonQuery();


                com.CommandText = "INSERT INTO Thesis (TITLE, ABSTRACT, AUTHOR, YEAR, TYPE, UNIVERSITY, INSTITUTE, SUPERVISOR, CO_SUPERVISOR, NUMBER_OF_PAGES, SUBJECT_TOPIC, KEYWORD, LANGUAGE, SUBMISSION_DATE) VALUES ('" + Title_textbox.Text + "','" + Abstract_textbox.Text + "','" + (authorIdentity + 1) + "','" + Int32.Parse(Year_textbox.Text) + "','" + DropDownList3.SelectedValue + "','" + (universityIdentity+1) + "','" + DropDownList4.SelectedValue + "','" + (supervisorIdentity+1) + "','" + (supervisorIdentity+1) + "','" + Int32.Parse(Num_of_pages_textbox.Text) + "','" + DropDownList1.Text + "','" + DropDownList2.Text + "','" + DropDownList5.Text + "', GETDATE())";
                com.ExecuteNonQuery();

                Literal1.Text = "<h3 class='h3 text-primary'> Submission accepted!</h1>";

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}