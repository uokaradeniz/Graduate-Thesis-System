<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Submission.aspx.cs" Inherits="Graduate_Thesis_System.Submission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thesis Submission | Graduate Thesis System</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="alert-warning text-center">Submission</h1>
        <div id="SelectionWindow" class="container" runat="server">
            <div class="row">
                <div class="col">
                    <asp:Literal ID="Literal2" Text="Please choose subject to add:" runat="server"></asp:Literal>
                    <asp:DropDownList ID="SelectionDropDownList" runat="server" OnSelectedIndexChanged="SelectionDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    <br />
                </div>
            </div>
        </div>

        <div class="submission_container">
            

            <table id="ThesisTable" visible="false" runat="server" class="col-12 table-bordered ms-5 ps-5 pb-2 pt-2 d-flex justify-content-center">

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

                        <asp:CheckBox ID="Co_SupervisorCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="Co_SupervisorCheckBox_CheckedChanged" Checked="True" />

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

                    </td>


                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Keyword" runat="server" Text="Keyword:"></asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" Width="200px" runat="server">
                        </asp:DropDownList>

                    </td>


                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Language" runat="server" Text="Language:"></asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList5" Width="200px" runat="server">
                        </asp:DropDownList>

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
            <table id="AuthorTable" visible="false" runat="server" class="col-12 table-bordered ms-5 ps-5 pb-2 pt-2 d-flex justify-content-center">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Author ID: "></asp:Label></td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text=" X "></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="First Name:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="Author_fNameTextBox" Width="200px" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="Author_fNameTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Last Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Author_lNameTextBox" Width="200px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="Author_lNameTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <table id="TypeTable" visible="false" runat="server" class="col-12 table-bordered ms-5 ps-5 pb-2 pt-2 d-flex justify-content-center">
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Type ID: "></asp:Label></td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text=" X "></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="New Type:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="Type_NameTextBox" Width="200px" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="Type_NameTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <table id="UniversityTable" visible="false" runat="server" class="col-12 table-bordered ms-5 ps-5 pb-2 pt-2 d-flex justify-content-center">
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="University ID: "></asp:Label></td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text=" X "></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="University Name:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="University_NameTextBox" Width="200px" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="University_NameTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Faculty Related Institute:"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="FRInstitute_DropDownList" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="FRInstitute_DropDownList" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <table id="InstituteTable" visible="false" runat="server" class="col-12 table-bordered ms-5 ps-5 pb-2 pt-2 d-flex justify-content-center">
                <tr>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="Institute ID: "></asp:Label></td>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text=" X "></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="Institute Name:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="Institute_NameTextBox" Width="200px" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ControlToValidate="Institute_NameTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <table id="SupervisorTable" visible="false" runat="server" class="col-12 table-bordered ms-5 ps-5 pb-2 pt-2 d-flex justify-content-center">
                <tr>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text="Supervisor ID: "></asp:Label></td>
                    <td>
                        <asp:Label ID="Label18" runat="server" Text=" X "></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label19" runat="server" Text="First Name:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="Supervisor_FnameTextBox" Width="200px" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="Supervisor_FnameTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label20" runat="server" Text="Last Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Supervisor_LnameTextBox" Width="200px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="Supervisor_LnameTextBox" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="Co Supervisor? : "></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="Cosupervisor_CheckBox" runat="server" />
                    </td>
                </tr>
            </table>

            <br />
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <br />
            <div class="d-flex justify-content-center mb-5 col-12">
                <asp:Button ID="Submit_button" CssClass="me-2 btn btn-danger" runat="server" Text="Submit" Width="200px" OnClick="Submit_button_Click" />
                <asp:Button ID="BackButton" CssClass="ms-2 btn btn-danger" runat="server" Text="Back" Width="200px" OnClick="BackButton_Click" CausesValidation="False" />
            </div>
        </div>
    </form>
</body>
</html>
