using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Graduate_Thesis_System
{
    public partial class Submission : System.Web.UI.Page
    {
        UsefulFunctions usefulFunctions = new UsefulFunctions();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                usefulFunctions.FillTypeList(DropDownList3);
                usefulFunctions.FillInstituteList(DropDownList4);
                usefulFunctions.FillTopicList(DropDownList1);
                usefulFunctions.FillKeywordList(DropDownList2);
                usefulFunctions.FillLanguageList(DropDownList5);
                usefulFunctions.FillAuthorList(DropDownList6);
                usefulFunctions.FillUniversityList(DropDownList7);
                usefulFunctions.FillSupervisorList(DropDownList8);
                usefulFunctions.FillCosupervisorList(DropDownList9);
            }
        }

        protected void Submit_button_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");
            try
            {
                con.Open();
                string query = "INSERT INTO Thesis (TITLE, ABSTRACT, AUTHOR, YEAR, TYPE, UNIVERSITY, INSTITUTE, SUPERVISOR, CO_SUPERVISOR, NUMBER_OF_PAGES, SUBJECT_TOPIC, KEYWORD, LANGUAGE, SUBMISSION_DATE) VALUES ('" + Title_textbox.Text + "','" + Abstract_textbox.Text + "','" + DropDownList6.SelectedValue + "','" + Int32.Parse(Year_textbox.Text) + "','" + DropDownList3.SelectedValue + "','" + DropDownList7.SelectedValue + "','" + DropDownList4.SelectedValue + "','" + DropDownList8.SelectedValue + "','" + DropDownList9.SelectedValue + "','" + Int32.Parse(Num_of_pages_textbox.Text) + "','" + DropDownList1.SelectedItem + "','" + DropDownList2.SelectedItem + "','" + DropDownList5.SelectedItem + "', GETDATE())";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Literal1.Text = "<h3 class='h3 text-primary'> Submission accepted!</h1>";

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}