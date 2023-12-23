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
                usefulFunctions.FillOnlyFKThesisDDL(SelectionDropDownList);
                SelectionDropDownList.Items[0].Text = "THESIS";
                SelectionDropDownList.Items[0].Value = "THESIS_NO";

                ThesisTable.Visible = true;

                usefulFunctions.FillTypeList(DropDownList3);
                usefulFunctions.FillInstituteList(DropDownList4);
                usefulFunctions.FillTopicList(DropDownList1);
                usefulFunctions.FillKeywordList(DropDownList2);
                usefulFunctions.FillLanguageList(DropDownList5);
                usefulFunctions.FillAuthorList(DropDownList6);
                usefulFunctions.FillUniversityList(DropDownList7);
                usefulFunctions.FillSupervisorList(DropDownList8);
                usefulFunctions.FillCosupervisorList(DropDownList9);
                usefulFunctions.FillInstituteList(FRInstitute_DropDownList);
            }
        }

        void SubmitSelection(string query)
        {
            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");
            try
            {
                con.Open();
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

        protected void Submit_button_Click(object sender, EventArgs e)
        {
            switch (SelectionDropDownList.SelectedValue)
            {
                case "THESIS_NO":
                    if (Co_SupervisorCheckBox.Checked)
                        SubmitSelection("INSERT INTO Thesis (TITLE, ABSTRACT, AUTHOR, YEAR, TYPE, UNIVERSITY, INSTITUTE, SUPERVISOR, CO_SUPERVISOR, NUMBER_OF_PAGES, SUBJECT_TOPIC, KEYWORD, LANGUAGE, SUBMISSION_DATE) VALUES ('" + Title_textbox.Text + "','" + Abstract_textbox.Text + "','" + DropDownList6.SelectedValue + "','" + Int32.Parse(Year_textbox.Text) + "','" + DropDownList3.SelectedValue + "','" + DropDownList7.SelectedValue + "','" + DropDownList4.SelectedValue + "','" + DropDownList8.SelectedValue + "','" + DropDownList9.SelectedValue + "','" + Int32.Parse(Num_of_pages_textbox.Text) + "','" + DropDownList1.SelectedItem + "','" + DropDownList2.SelectedItem + "','" + DropDownList5.SelectedItem + "', GETDATE())");
                    else
                        SubmitSelection("INSERT INTO Thesis (TITLE, ABSTRACT, AUTHOR, YEAR, TYPE, UNIVERSITY, INSTITUTE, SUPERVISOR, CO_SUPERVISOR, NUMBER_OF_PAGES, SUBJECT_TOPIC, KEYWORD, LANGUAGE, SUBMISSION_DATE) VALUES ('" + Title_textbox.Text + "','" + Abstract_textbox.Text + "','" + DropDownList6.SelectedValue + "','" + Int32.Parse(Year_textbox.Text) + "','" + DropDownList3.SelectedValue + "','" + DropDownList7.SelectedValue + "','" + DropDownList4.SelectedValue + "','" + DropDownList8.SelectedValue + "','" + 0 + "','" + Int32.Parse(Num_of_pages_textbox.Text) + "','" + DropDownList1.SelectedItem + "','" + DropDownList2.SelectedItem + "','" + DropDownList5.SelectedItem + "', GETDATE())");

                    break;
                case "AUTHOR":
                    SubmitSelection("INSERT INTO Author (FIRST_NAME, LAST_NAME) VALUES ('" + Author_fNameTextBox.Text + "','" + Author_lNameTextBox.Text + "')");
                    break;
                case "TYPE":
                    SubmitSelection("INSERT INTO Type (TYPE_NAME) VALUES ('" + Type_NameTextBox.Text + "')");
                    break;
                case "UNIVERSITY":
                    SubmitSelection("INSERT INTO University (NAME, INSTITUTE) VALUES ('" + University_NameTextBox.Text + "','" + FRInstitute_DropDownList.SelectedValue + "')");
                    break;
                case "INSTITUTE":
                    SubmitSelection("INSERT INTO Institute (NAME) VALUES ('" + Institute_NameTextBox.Text + "')");
                    break;
                case "SUPERVISOR":
                    SubmitSelection("INSERT INTO Supervisor (FIRST_NAME, LAST_NAME, IS_CO_SUPERVISOR) VALUES ('" + Supervisor_FnameTextBox.Text + "','" + Supervisor_LnameTextBox.Text + "','" + Cosupervisor_CheckBox.Checked + "')");
                    break;
                default:
                    break;
            }
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void SelectionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectionDropDownList.SelectedValue == "THESIS_NO")
            {
                ThesisTable.Visible = true;
                AuthorTable.Visible = false;
                TypeTable.Visible = false;
                UniversityTable.Visible = false;
                InstituteTable.Visible = false;
                SupervisorTable.Visible = false;
            }
            else if (SelectionDropDownList.SelectedValue == "AUTHOR")
            {
                ThesisTable.Visible = false;
                AuthorTable.Visible = true;
                TypeTable.Visible = false;
                UniversityTable.Visible = false;
                InstituteTable.Visible = false;
                SupervisorTable.Visible = false;
            }
            else if (SelectionDropDownList.SelectedValue == "TYPE")
            {
                ThesisTable.Visible = false;
                AuthorTable.Visible = false;
                TypeTable.Visible = true;
                UniversityTable.Visible = false;
                InstituteTable.Visible = false;
                SupervisorTable.Visible = false;
            }
            else if (SelectionDropDownList.SelectedValue == "UNIVERSITY")
            {
                ThesisTable.Visible = false;
                AuthorTable.Visible = false;
                TypeTable.Visible = false;
                UniversityTable.Visible = true;
                InstituteTable.Visible = false;
                SupervisorTable.Visible = false;
            }
            else if (SelectionDropDownList.SelectedValue == "INSTITUTE")
            {
                ThesisTable.Visible = false;
                AuthorTable.Visible = false;
                TypeTable.Visible = false;
                UniversityTable.Visible = false;
                InstituteTable.Visible = true;
                SupervisorTable.Visible = false;
            }
            else if (SelectionDropDownList.SelectedValue == "SUPERVISOR")
            {
                ThesisTable.Visible = false;
                AuthorTable.Visible = false;
                TypeTable.Visible = false;
                UniversityTable.Visible = false;
                InstituteTable.Visible = false;
                SupervisorTable.Visible = true;
            }
        }

        protected void Co_SupervisorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Co_SupervisorCheckBox.Checked)
            {
                DropDownList9.Enabled = false;
            }
            else
            {
                DropDownList9.Enabled = true;
            }
        }
    }
}