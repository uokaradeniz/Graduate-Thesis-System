<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Submission.aspx.cs" Inherits="Graduate_Thesis_System.Submission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thesis Submission | Graduate Thesis System</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="submission_container">
            <h1 class="alert-warning text-center">Submission</h1>
            <table class="col-12 table-bordered ms-5 ps-5 pb-2 pt-2 d-flex justify-content-center">

                <tr>
                    <td>
                        <asp:Label ID="Thesis_No" runat="server" Text="Thesis Number: "></asp:Label></td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Auto Assigned."></asp:Label></td>
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
                        <asp:Label ID="FirstName" runat="server" Text="Author First Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Firstname_textbox" Width="200px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="Firstname_textbox" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="LastName" runat="server" Text="Author Last Name:"></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="Lastname_textbox" Width="200px" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ControlToValidate="Lastname_textbox" ForeColor="Red"></asp:RequiredFieldValidator>

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
                        <asp:TextBox ID="University_textbox" Width="200px" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="University_textbox" ForeColor="Red"></asp:RequiredFieldValidator>

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
                        <asp:Label ID="SupervisorFname" runat="server" Text="Supervisor First Name:"></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="SupervisorFname_textbox" Width="200px" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="SupervisorFname_textbox" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>

                </tr>

                <tr>
                    <td>
                        <asp:Label ID="SupervisorLname" runat="server" Text="Supervisor Last Name:"></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="SupervisorLname_textbox" Width="200px" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ControlToValidate="SupervisorLname_textbox" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Co_Supervisor" runat="server" Text="Co-Supervisor: "></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="Cosupervisor_textbox" Width="200px" runat="server"></asp:TextBox>

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
                        <asp:Label ID="Label2" runat="server" Text="Auto Assigned."></asp:Label>

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
