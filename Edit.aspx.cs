using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using System.Collections;

namespace Graduate_Thesis_System
{
    public partial class Edit : System.Web.UI.Page
    {
        static int ThesisNo;
        static int AuthorId;
        static int TypeId;
        static int UniversityId;
        static int InstituteId;
        static int SupervisorId;

        FKLoader FKLoader;
        UsefulFunctions usefulFunctions;
        protected void Page_Load(object sender, EventArgs e)
        {
            FKLoader = new FKLoader();
            usefulFunctions = new UsefulFunctions();
            if (!IsPostBack)
            {
                OperationWindow.Visible = false;
                usefulFunctions.FillOnlyFKThesisDDL(SelectionDropDownList);
                SelectionDropDownList.Items[0].Text = "THESIS";
                SelectionDropDownList.Items[0].Value = "THESIS_NO";
                FKLoader.BindGridView(SelectionGridView, SelectionDropDownList);

            }
        }

        void EditSelection(string query)
        {
            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Literal8.Text = $"<h3 class='h3 text-primary'>{rowsAffected} row(s) affected. Operation Successful!</h3>";
                con.Close();
            }
            catch (Exception ex) { Response.Write(ex); }
        }

        void DeleteSelection(string query)
        {

            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Literal8.Text = $"<h3 class='h3 text-primary'>{rowsAffected} row(s) affected. Operation Successful!</h3>";
                con.Close();
            }
            catch (Exception ex) { Response.Write(ex.Message); }

        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            if (rblOptions.SelectedItem.Text == "Edit")
            {
                switch (SelectionDropDownList.SelectedValue)
                {
                    case "THESIS_NO":
                        if (Co_supervisorCheckBox.Checked)
                            EditSelection("UPDATE Thesis SET TITLE = '" + Title_textbox.Text + "',ABSTRACT = '" + Abstract_textbox.Text + "', AUTHOR = '" + DropDownList3.SelectedValue + "',YEAR = '" + Year_textbox.Text + "', TYPE = '" + DropDownList3.SelectedValue + "', UNIVERSITY = '" + DropDownList7.SelectedValue + "' ,INSTITUTE = '" + DropDownList4.SelectedValue + "', SUPERVISOR = '" + DropDownList8.SelectedValue + "',CO_SUPERVISOR = '" + DropDownList9.SelectedValue + "',NUMBER_OF_PAGES = '" + Num_of_pages_textbox.Text + "',SUBJECT_TOPIC = '" + DropDownList1.SelectedItem + "', KEYWORD = '" + DropDownList2.SelectedItem + "', LANGUAGE = '" + DropDownList5.SelectedItem + "' WHERE THESIS_NO = '" + ThesisNo + "'");
                        else
                            EditSelection("UPDATE Thesis SET TITLE = '" + Title_textbox.Text + "',ABSTRACT = '" + Abstract_textbox.Text + "', AUTHOR = '" + DropDownList3.SelectedValue + "',YEAR = '" + Year_textbox.Text + "', TYPE = '" + DropDownList3.SelectedValue + "', UNIVERSITY = '" + DropDownList7.SelectedValue + "' ,INSTITUTE = '" + DropDownList4.SelectedValue + "', SUPERVISOR = '" + DropDownList8.SelectedValue + "',CO_SUPERVISOR = '" + 0 + "',NUMBER_OF_PAGES = '" + Num_of_pages_textbox.Text + "',SUBJECT_TOPIC = '" + DropDownList1.SelectedItem + "', KEYWORD = '" + DropDownList2.SelectedItem + "', LANGUAGE = '" + DropDownList5.SelectedItem + "' WHERE THESIS_NO = '" + ThesisNo + "'");
                        break;
                    case "AUTHOR":
                        EditSelection("UPDATE Author SET FIRST_NAME = '" + Author_fNameTextBox.Text + "', LAST_NAME = '" + Author_lNameTextBox.Text + "' WHERE AUTHOR_ID= '" + AuthorId + "'");
                        break;
                    case "TYPE":
                        EditSelection("UPDATE Type SET TYPE_NAME = '" + Type_NameTextBox.Text + "' WHERE TYPE_ID = '" + TypeId + "'");
                        break;
                    case "UNIVERSITY":
                        EditSelection("UPDATE University SET NAME = '" + University_NameTextBox.Text + "', INSTITUTE = '" + FRInstitute_DropDownList.SelectedValue + "' WHERE UNIVERSITY_ID = '" + UniversityId + "'");
                        break;
                    case "INSTITUTE":
                        EditSelection("UPDATE Institute SET NAME = '" + Institute_NameTextBox.Text + "' WHERE INSTITUTE_ID = '" + InstituteId + "'");
                        break;
                    case "SUPERVISOR":
                        EditSelection("UPDATE Supervisor SET FIRST_NAME = '" + Supervisor_FnameTextBox.Text + "', LAST_NAME = '" + Supervisor_LnameTextBox.Text + "', IS_CO_SUPERVISOR = '" + Cosupervisor_CheckBox.Checked + "' WHERE SUPERVISOR_ID = '" + SupervisorId + "'");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (SelectionDropDownList.SelectedValue)
                {
                    case "THESIS_NO":
                        DeleteSelection($"DELETE FROM Thesis WHERE THESIS_NO = {ThesisNo}");
                        break;
                    case "AUTHOR":
                        DeleteSelection($"DELETE FROM Author WHERE AUTHOR_ID = {AuthorId}");
                        break;
                    case "TYPE":
                        DeleteSelection($"DELETE FROM Type WHERE TYPE_ID = {TypeId}");
                        break;
                    case "UNIVERSITY":
                        DeleteSelection($"DELETE FROM University WHERE UNIVERSITY_ID = {UniversityId}");
                        break;
                    case "INSTITUTE":
                        DeleteSelection($"DELETE FROM Institute WHERE INSTITUTE_ID = {InstituteId}");
                        break;
                    case "SUPERVISOR":
                        DeleteSelection($"DELETE FROM Supervisor WHERE SUPERVISOR_ID = {SupervisorId}");
                        break;
                    default:
                        break;
                }
            }
        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            SelectionWindow.Visible = false;
            SelectionGridView.Visible = false;
            if (SelectionDropDownList.SelectedValue == "THESIS_NO")
            {
                ThesisTable.Visible = true;

                ThesisEditForm();
            }
            else if (SelectionDropDownList.SelectedValue == "AUTHOR")
            {
                AuthorTable.Visible = true;
                AuthorId = Int32.Parse(TextBox1.Text);
                string query = $"SELECT * FROM Author WHERE AUTHOR_ID = {AuthorId}";
                OtherEditForms(query);
            }
            else if (SelectionDropDownList.SelectedValue == "TYPE")
            {
                TypeTable.Visible = true;
                TypeId = Int32.Parse(TextBox2.Text);
                string query = $"SELECT * FROM Type WHERE TYPE_ID = {TypeId}";
                OtherEditForms(query);
            }
            else if (SelectionDropDownList.SelectedValue == "UNIVERSITY")
            {
                UniversityTable.Visible = true;
                usefulFunctions.FillInstituteList(FRInstitute_DropDownList);
                UniversityId = Int32.Parse(TextBox3.Text);
                string query = $"SELECT * FROM University WHERE UNIVERSITY_ID = {UniversityId}";
                OtherEditForms(query);

            }
            else if (SelectionDropDownList.SelectedValue == "INSTITUTE")
            {
                InstituteTable.Visible = true;
                InstituteId = Int32.Parse(TextBox4.Text);
                string query = $"SELECT * FROM Institute WHERE INSTITUTE_ID = {InstituteId}";
                OtherEditForms(query);
            }
            else if (SelectionDropDownList.SelectedValue == "SUPERVISOR")
            {
                SupervisorTable.Visible = true;
                SupervisorId = Int32.Parse(TextBox5.Text);
                string query = $"SELECT * FROM Supervisor WHERE SUPERVISOR_ID = {SupervisorId}";
                OtherEditForms(query);
            }
        }

        void OtherEditForms(string query)
        {

            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    OtherGridView.DataSource = dt;
                    OtherGridView.DataBind();

                    OperationWindow.Visible = true;
                }
                else
                {
                    Literal8.Text = $"<h3 class='h3 text-primary'>No Value with id {ThesisNo} found!</h3>";
                }
                con.Close();
                dt.Dispose();

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        void ThesisEditForm()
        {
            SelectionWindow.Visible = false;
            SelectionGridView.Visible = false;

            usefulFunctions.FillTypeList(DropDownList3);
            usefulFunctions.FillInstituteList(DropDownList4);
            usefulFunctions.FillTopicList(DropDownList1);
            usefulFunctions.FillKeywordList(DropDownList2);
            usefulFunctions.FillLanguageList(DropDownList5);
            usefulFunctions.FillAuthorList(DropDownList6);
            usefulFunctions.FillUniversityList(DropDownList7);
            usefulFunctions.FillSupervisorList(DropDownList8);
            usefulFunctions.FillCosupervisorList(DropDownList9);


            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");
            try
            {
                ThesisNo = Int32.Parse(ThesisNoTextbox.Text);
                string query = $"SELECT * FROM Thesis WHERE THESIS_NO = {ThesisNo}";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //i had serious problems with changing foreign key values tried multiple things
                    //like sql JOIN Clause, DataTable value changing and
                    //at last i found a solution with only changing the view with gridView
                    GridView.DataSource = dt;
                    GridView.DataBind();
                    FKLoader.UpdateGridView(GridView);

                    OperationWindow.Visible = true;
                }
                else
                {
                    Literal8.Text = $"<h3 class='h3 text-primary'>No Thesis with id {ThesisNo} found!</h3>";
                }
                con.Close();
                dt.Dispose();

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");

        }

        protected void SelectionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectionDropDownList.SelectedValue == "THESIS_NO")
            {
                ThesisEditWindow.Visible = true;
                AuthorEditWindow.Visible = false;
                TypeEditWindow.Visible = false;
                UniversityEditWindow.Visible = false;
                InstituteEditWindow.Visible = false;
                SupervisorEditWindow.Visible = false;
                FKLoader.BindGridView(SelectionGridView, SelectionDropDownList);
                FKLoader.UpdateGridView(SelectionGridView);
            }
            else if (SelectionDropDownList.SelectedValue == "AUTHOR")
            {
                ThesisEditWindow.Visible = false;
                AuthorEditWindow.Visible = true;
                TypeEditWindow.Visible = false;
                UniversityEditWindow.Visible = false;
                InstituteEditWindow.Visible = false;
                SupervisorEditWindow.Visible = false;
                FKLoader.BindGridView(SelectionGridView, SelectionDropDownList);
            }
            else if (SelectionDropDownList.SelectedValue == "TYPE")
            {
                ThesisEditWindow.Visible = false;
                AuthorEditWindow.Visible = false;
                TypeEditWindow.Visible = true;
                UniversityEditWindow.Visible = false;
                InstituteEditWindow.Visible = false;
                SupervisorEditWindow.Visible = false;
                FKLoader.BindGridView(SelectionGridView, SelectionDropDownList);
            }
            else if (SelectionDropDownList.SelectedValue == "UNIVERSITY")
            {
                ThesisEditWindow.Visible = false;
                AuthorEditWindow.Visible = false;
                TypeEditWindow.Visible = false;
                UniversityEditWindow.Visible = true;
                InstituteEditWindow.Visible = false;
                SupervisorEditWindow.Visible = false;
                FKLoader.BindGridView(SelectionGridView, SelectionDropDownList);
                FKLoader.UpdateUniversityGridView(SelectionGridView);
            }
            else if (SelectionDropDownList.SelectedValue == "INSTITUTE")
            {
                ThesisEditWindow.Visible = false;
                AuthorEditWindow.Visible = false;
                TypeEditWindow.Visible = false;
                UniversityEditWindow.Visible = false;
                InstituteEditWindow.Visible = true;
                SupervisorEditWindow.Visible = false;
                FKLoader.BindGridView(SelectionGridView, SelectionDropDownList);
            }
            else if (SelectionDropDownList.SelectedValue == "SUPERVISOR")
            {
                ThesisEditWindow.Visible = false;
                AuthorEditWindow.Visible = false;
                TypeEditWindow.Visible = false;
                UniversityEditWindow.Visible = false;
                InstituteEditWindow.Visible = false;
                SupervisorEditWindow.Visible = true;
                FKLoader.BindGridView(SelectionGridView, SelectionDropDownList);
            }
        }

        protected void rblOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblOptions.SelectedItem.Text == "Edit")
            {

                switch (SelectionDropDownList.SelectedValue)
                {
                    case "THESIS_NO":
                        Title_textbox.Enabled = true;
                        Abstract_textbox.Enabled = true;
                        DropDownList1.Enabled = true;
                        DropDownList2.Enabled = true;
                        DropDownList3.Enabled = true;
                        DropDownList4.Enabled = true;
                        DropDownList5.Enabled = true;
                        DropDownList6.Enabled = true;
                        DropDownList7.Enabled = true;
                        DropDownList8.Enabled = true;
                        DropDownList9.Enabled = true;
                        Year_textbox.Enabled = true;
                        Num_of_pages_textbox.Enabled = true;
                        RequiredFieldValidator1.Enabled = true;
                        RequiredFieldValidator2.Enabled = true;
                        RequiredFieldValidator4.Enabled = true;
                        RequiredFieldValidator8.Enabled = true;
                        Co_supervisorCheckBox.Enabled = true;
                        break;
                    case "AUTHOR":
                        Author_fNameTextBox.Enabled = true;
                        Author_lNameTextBox.Enabled = true;
                        break;
                    case "TYPE":
                        Type_NameTextBox.Enabled = true;
                        break;
                    case "UNIVERSITY":
                        University_NameTextBox.Enabled = true;
                        FRInstitute_DropDownList.Enabled = true;
                        break;
                    case "INSTITUTE":
                        Institute_NameTextBox.Enabled = true;
                        break;
                    case "SUPERVISOR":
                        Supervisor_FnameTextBox.Enabled = true;
                        Supervisor_LnameTextBox.Enabled = true;
                        Cosupervisor_CheckBox.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (SelectionDropDownList.SelectedValue)
                {
                    case "THESIS_NO":
                        Title_textbox.Enabled = false;
                        Abstract_textbox.Enabled = false;
                        DropDownList1.Enabled = false;
                        DropDownList2.Enabled = false;
                        DropDownList3.Enabled = false;
                        DropDownList4.Enabled = false;
                        DropDownList5.Enabled = false;
                        DropDownList6.Enabled = false;
                        DropDownList7.Enabled = false;
                        DropDownList8.Enabled = false;
                        DropDownList9.Enabled = false;
                        Year_textbox.Enabled = false;
                        Num_of_pages_textbox.Enabled = false;
                        RequiredFieldValidator1.Enabled = false;
                        RequiredFieldValidator2.Enabled = false;
                        RequiredFieldValidator4.Enabled = false;
                        RequiredFieldValidator8.Enabled = false;
                        Co_supervisorCheckBox.Enabled = false;
                        break;
                    case "AUTHOR":
                        Author_fNameTextBox.Enabled = false;
                        Author_lNameTextBox.Enabled = false;
                        break;
                    case "TYPE":
                        Type_NameTextBox.Enabled = false;
                        break;
                    case "UNIVERSITY":
                        University_NameTextBox.Enabled = false;
                        FRInstitute_DropDownList.Enabled = false;
                        break;
                    case "INSTITUTE":
                        Institute_NameTextBox.Enabled = false;
                        break;
                    case "SUPERVISOR":
                        Supervisor_FnameTextBox.Enabled = false;
                        Supervisor_LnameTextBox.Enabled = false;
                        Cosupervisor_CheckBox.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
        }

        protected void Co_supervisorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Co_supervisorCheckBox.Checked)
            {
                DropDownList9.Enabled = false;
            }
            else
            {
                DropDownList9.Enabled = true;
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