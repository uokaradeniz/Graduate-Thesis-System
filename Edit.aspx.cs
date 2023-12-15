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
    public partial class Edit : System.Web.UI.Page
    {
        static int Thesis_No;
        FKLoader FKLoader;
        UsefulFunctions usefulFunctions;
        protected void Page_Load(object sender, EventArgs e)
        {
            OperationWindow.Visible = false;
            ReturnHomeButton.Visible = false;
            FKLoader = new FKLoader();
            usefulFunctions = new UsefulFunctions();
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");
            try
            {
                string query = "UPDATE Thesis SET TITLE = '" + Title_textbox.Text + "',ABSTRACT = '" + Abstract_textbox.Text + "', YEAR = '" + Year_textbox.Text + "', TYPE = '" + (DropDownList3.SelectedIndex + 1) + "', INSTITUTE = '" + (DropDownList4.SelectedIndex + 1) + "',  NUMBER_OF_PAGES = '" + Num_of_pages_textbox.Text + "',SUBJECT_TOPIC = '" + DropDownList1.SelectedItem +"', KEYWORD = '" + DropDownList2.SelectedItem + "', LANGUAGE = '" + DropDownList5.SelectedItem + "' WHERE THESIS_NO = '" + Thesis_No + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Response.Write($"{rowsAffected} row(s) affected.");
                con.Close();
                Response.Write("Operation Successfull!");
            }
            catch (Exception ex) { Response.Write(ex); }
            ReturnHomeButton.Visible = true;

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");
            try
            {
                string query = $"DELETE FROM Thesis WHERE THESIS_NO = {Thesis_No}";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Response.Write($"{rowsAffected} row(s) affected.");
                con.Close();
                Response.Write("Operation Successfull!");
            }
            catch (Exception ex) { Response.Write(ex.Message); }
            ReturnHomeButton.Visible = true;

        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            SelectionWindow.Visible = false;

            SqlConnection con = new SqlConnection("Data Source=UGUROGUZHANPC;Initial Catalog=GraduateThesisSystem;Integrated Security=True;");
            try
            {
                Thesis_No = Int32.Parse(ThesisNoTextbox.Text);
                string query = $"SELECT * FROM Thesis WHERE THESIS_NO = {Thesis_No}";

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
                    Title_textbox.Text = GridView.Rows[0].Cells[1].Text;
                    Abstract_textbox.Text = GridView.Rows[0].Cells[2].Text;
                    Year_textbox.Text = GridView.Rows[0].Cells[4].Text;
                    Num_of_pages_textbox.Text = GridView.Rows[0].Cells[10].Text;

                    OperationWindow.Visible = true;
                }
                else
                {
                    Response.Write($"No Thesis with id {Thesis_No} found!");
                    ReturnHomeButton.Visible = true;
                }
                con.Close();
                dt.Dispose();

            }
            catch (Exception ex)
            {
                Response.Write(ex);
                ReturnHomeButton.Visible = true;
            }

            usefulFunctions.FillTypeList(DropDownList3);
            usefulFunctions.FillInstituteList(DropDownList4);
            usefulFunctions.FillTopicList(DropDownList1);
            usefulFunctions.FillKeywordList(DropDownList2);
            usefulFunctions.FillLanguageList(DropDownList5);
        }

        protected void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");

        }
    }
}