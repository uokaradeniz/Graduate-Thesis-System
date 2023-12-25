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
        UsefulFunctions usefulFunctions;
        FKLoader fKLoader;
        static bool selectionHasFK = false;
        string searchWord;
        protected void Page_Load(object sender, EventArgs e)
        {
            usefulFunctions = new UsefulFunctions();
            fKLoader = new FKLoader();
            if (!IsPostBack)
            {
                ListItem all = new ListItem("All");
                SearchDropDownList.Items.Add(all);
                usefulFunctions.FillThesisDDL(SearchDropDownList);
            }
        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");
           
            if(!selectionHasFK)
                searchWord = SearchTextBox.Text;
            else
                searchWord = SelectDropDownList.Text;
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
            fKLoader.UpdateGridView(GridView1);
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void SelectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SearchDropDownList.SelectedValue)
            {
                case "AUTHOR":
                    usefulFunctions.FillAuthorList(SelectDropDownList);
                    SelectDropDownList.Visible = true;
                    SearchTextBox.Visible = false;
                    rfvInput.Enabled = false;
                    selectionHasFK = true;
                    break;
                case "TYPE":
                    usefulFunctions.FillTypeList(SelectDropDownList);
                    SelectDropDownList.Visible = true;
                    SearchTextBox.Visible = false;
                    rfvInput.Enabled = false;
                    selectionHasFK = true;
                    break;
                case "UNIVERSITY":
                    usefulFunctions.FillUniversityList(SelectDropDownList);
                    SelectDropDownList.Visible = true;
                    SearchTextBox.Visible = false;
                    rfvInput.Enabled = false;
                    selectionHasFK = true;
                    break;
                case "INSTITUTE":
                    usefulFunctions.FillInstituteList(SelectDropDownList);
                    SelectDropDownList.Visible = true;
                    SearchTextBox.Visible = false;
                    rfvInput.Enabled = false;
                    selectionHasFK = true;
                    break;
                case "SUPERVISOR":
                    usefulFunctions.FillSupervisorList(SelectDropDownList);
                    SelectDropDownList.Visible = true;
                    SearchTextBox.Visible = false;
                    rfvInput.Enabled = false;
                    selectionHasFK = true;
                    break;
                case "CO_SUPERVISOR":
                    usefulFunctions.FillCosupervisorList(SelectDropDownList);
                    SelectDropDownList.Visible = true;
                    SearchTextBox.Visible = false;
                    rfvInput.Enabled = false;
                    selectionHasFK = true;
                    break;
                case "SUBJECT_TOPIC":
                    usefulFunctions.FillTopicList(SelectDropDownList);
                    SelectDropDownList.Visible = true;
                    SearchTextBox.Visible = false;
                    rfvInput.Enabled = false;
                    selectionHasFK = true;
                    break;
                case "KEYWORD":
                    usefulFunctions.FillKeywordList(SelectDropDownList);
                    SelectDropDownList.Visible = true;
                    SearchTextBox.Visible = false;
                    rfvInput.Enabled = false;
                    selectionHasFK = true;
                    break;
                case "LANGUAGE":
                    usefulFunctions.FillLanguageList(SelectDropDownList);
                    SelectDropDownList.Visible = true;
                    SearchTextBox.Visible = false;
                    rfvInput.Enabled = false;
                    selectionHasFK = true;
                    break;
                default:
                    SearchTextBox.Visible = true;
                    SelectDropDownList.Visible = false;
                    rfvInput.Enabled = true;
                    selectionHasFK = false;
                    break;
            }
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void EditDeleteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx");
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Submission.aspx");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx");
        }
    }
}