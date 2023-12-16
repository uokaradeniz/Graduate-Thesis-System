<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Graduate_Thesis_System.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">

    <title>Edit/Delete Thesis | Graduate Thesis System</title>

</head>
<body>
    <form id="form1" runat="server">
        <h1 class="h1 alert-warning text-center p-2">Edit / Delete Thesis</h1>
        <div id="SelectionWindow" style="margin-top: 20%;" class="col-12 d-flex justify-content-center align-items-center" runat="server">
            <asp:Literal ID="Literal1" runat="server" Text="Please enter a Thesis Number: "></asp:Literal>
            <asp:TextBox ID="ThesisNoTextbox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ContinueButton" CssClass="m-2 btn btn-danger" runat="server" Text="Continue" OnClick="ContinueButton_Click" />
            <asp:Button ID="BackButton" CssClass="m-2 btn btn-danger" runat="server" Text="Back" OnClick="BackButton_Click" />

        </div>

        <div id="OperationWindow" runat="server">
            <asp:GridView ID="GridView" CssClass="table-bordered table-hover" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="THESIS_NO" HeaderText="Thesis No" />
                    <asp:BoundField DataField="TITLE" HeaderText="Title" />
                    <asp:BoundField DataField="ABSTRACT" HeaderText="Abstract" />
                    <asp:BoundField DataField="AUTHOR" HeaderText="Author" />
                    <asp:BoundField DataField="YEAR" HeaderText="Year" />
                    <asp:BoundField DataField="TYPE" HeaderText="Type" />
                    <asp:BoundField DataField="UNIVERSITY" HeaderText="University" />
                    <asp:BoundField DataField="INSTITUTE" HeaderText="Institute" />
                    <asp:BoundField DataField="SUPERVISOR" HeaderText="Supervisor" />
                    <asp:BoundField DataField="CO_SUPERVISOR" HeaderText="Co-Supervisor" />
                    <asp:BoundField DataField="NUMBER_OF_PAGES" HeaderText="Number of Pages" />
                    <asp:BoundField DataField="SUBJECT_TOPIC" HeaderText="Subject Topic" />
                    <asp:BoundField DataField="KEYWORD" HeaderText="Keyword" />
                    <asp:BoundField DataField="LANGUAGE" HeaderText="Language" />
                    <asp:BoundField DataField="SUBMISSION_DATE" HeaderText="Submission Date" />
                </Columns>
            </asp:GridView>

            <table class="col-12 table-bordered ms-5 ps-5 pb-2 pt-2 d-flex justify-content-center">

                <tr>
                    <td>
                        <asp:Label ID="Thesis_No" runat="server" Text="Thesis Number: "></asp:Label></td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text=" X "></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Title" runat="server" Text="Title:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="Title_textbox" Width="200px" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="Title_textbox" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Abstract" runat="server" Text="Abstract:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Abstract_textbox" Width="200px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="Abstract_textbox" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Author" runat="server" Text="Author: "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList6" Width="200px" runat="server">
                        </asp:DropDownList>

                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Year" runat="server" Text="Year:"></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="Year_textbox" Width="200px" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="Year_textbox" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Type" runat="server" Text="Type:"></asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList3" Width="200px" runat="server">
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="DropDownList3" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="University" runat="server" Text="University:"></asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList7" Width="200px" runat="server">
                        </asp:DropDownList>

                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Institute" runat="server" Text="Institute:"></asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList4" Width="200px" runat="server">
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="DropDownList4" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="SupervisorFname" runat="server" Text="Supervisor:"></asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList8" Width="200px" runat="server">
                        </asp:DropDownList>

                    </td>

                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Co_Supervisor" runat="server" Text="Co-Supervisor: "></asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList9" Width="200px" runat="server">
                        </asp:DropDownList>

                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Num_of_pages" runat="server" Text="Number of Pages:"></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="Num_of_pages_textbox" Width="200px" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="Num_of_pages_textbox" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>

                </tr>

                <tr>
                    <td>
                        <asp:Label ID="SubjectTopic" runat="server" Text="Subject Topic:"></asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" Width="200px" runat="server">
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ControlToValidate="DropDownList1" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>


                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Keyword" runat="server" Text="Keyword:"></asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" Width="200px" runat="server">
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ControlToValidate="DropDownList2" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>


                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Language" runat="server" Text="Language:"></asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList5" Width="200px" runat="server">
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="DropDownList5" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Submission_date" runat="server" Text="Submission Date: "></asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text=" X "></asp:Label>

                    </td>
                </tr>
            </table>

            <asp:Button ID="EditButton" CssClass="m-2 btn btn-danger" runat="server" Text="Edit" OnClick="EditButton_Click" />
            <asp:Button ID="DeleteButton" CssClass="m-2 btn btn-danger" runat="server" Text="Delete" OnClick="DeleteButton_Click" CausesValidation="False" />
            <asp:Button ID="Button1" CssClass="m-2 btn btn-danger" runat="server" Text="Back" OnClick="BackButton_Click" />

        </div>
        <asp:Button ID="ReturnHomeButton" CssClass="m-2 btn btn-danger" runat="server" Text="Return to Home Page" OnClick="ReturnHomeButton_Click" />
    </form>
</body>
</html>
