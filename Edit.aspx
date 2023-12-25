<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Graduate_Thesis_System.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">

    <title>Edit/Delete Thesis | Graduate Thesis System</title>

</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar alert-warning mb-3">
            <h1 class="h1 navbar-text text-primary" style="text-align: center;">Graduate Thesis System</h1>
            <h2 class="h2 navbar-text text-primary" style="text-align: center;">Edit - Delete</h2>
            <div class="d-flex justify-content-center p-3 card-header bg-info bg-opacity-50">
                <asp:Button ID="HomeButton" runat="server" Text="Home" CssClass="m-2 btn btn-danger" Width="200px" CausesValidation="False" OnClick="HomeButton_Click" />
                <asp:Button ID="EditDeleteButton" runat="server" Text="Edit | Delete" CssClass="m-2 btn btn-danger" Width="200px" CausesValidation="False" OnClick="EditDeleteButton_Click" />
                <asp:Button ID="SubmitButton" runat="server" Text="Submission" CssClass="m-2 btn btn-danger" Width="200px" OnClick="SubmitButton_Click" CausesValidation="False" />
                <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="m-2 btn btn-danger" Width="200px" OnClick="SearchButton_Click" CausesValidation="False" />
            </div>
        </nav>

        <div id="SelectionWindow" class="container" runat="server">
            <div class="card row mb-2">
                <div class="col-sm text-center card-body">
                    <asp:Literal ID="Literal2" Text="Please choose the subject to edit:" runat="server"></asp:Literal>
                    <asp:DropDownList ID="SelectionDropDownList" runat="server" OnSelectedIndexChanged="SelectionDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>
            <div class="card row mb-2">
                <div class="col-sm text-center card-body">
                    <div id="ThesisEditWindow" runat="server">
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <asp:Literal ID="Literal1" runat="server" Text="Please enter a Thesis Number: "></asp:Literal>
                                <asp:TextBox ID="ThesisNoTextbox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ControlToValidate="ThesisNoTextbox" ForeColor="Red"></asp:RequiredFieldValidator>
                            </li>
                            <li class="list-group-item">
                                <asp:Button ID="ContinueButton" CssClass="m-2 btn btn-danger" runat="server" Text="Continue" OnClick="ContinueButton_Click" />
                            </li>
                        </ul>
                    </div>
                    <div id="AuthorEditWindow" visible="false" runat="server">
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <asp:Literal ID="Literal3" runat="server" Text="Please enter Author ID: "></asp:Literal>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
                            </li>
                            <li class="list-group-item">
                                <asp:Button ID="Button2" CssClass="m-2 btn btn-danger" runat="server" Text="Continue" OnClick="ContinueButton_Click" />
                            </li>
                        </ul>
                    </div>
                    <div id="TypeEditWindow" visible="false" runat="server">
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <asp:Literal ID="Literal4" runat="server" Text="Please enter Type ID: "></asp:Literal>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>
                            </li>
                            <li class="list-group-item">
                                <asp:Button ID="Button4" CssClass="m-2 btn btn-danger" runat="server" Text="Continue" OnClick="ContinueButton_Click" />
                            </li>
                        </ul>
                    </div>
                    <div id="UniversityEditWindow" visible="false" runat="server">
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <asp:Literal ID="Literal5" runat="server" Text="Please enter University ID: "></asp:Literal>
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ControlToValidate="TextBox3" ForeColor="Red"></asp:RequiredFieldValidator>
                            </li>
                            <li class="list-group-item">
                                <asp:Button ID="Button6" CssClass="m-2 btn btn-danger" runat="server" Text="Continue" OnClick="ContinueButton_Click" />
                            </li>
                        </ul>
                    </div>
                    <div id="InstituteEditWindow" visible="false" runat="server">
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <asp:Literal ID="Literal6" runat="server" Text="Please enter Institute ID: "></asp:Literal>
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ControlToValidate="TextBox4" ForeColor="Red"></asp:RequiredFieldValidator>
                            </li>
                            <li class="list-group-item">
                                <asp:Button ID="Button8" CssClass="m-2 btn btn-danger" runat="server" Text="Continue" OnClick="ContinueButton_Click" />
                            </li>
                        </ul>
                    </div>
                    <div id="SupervisorEditWindow" visible="false" runat="server">
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <asp:Literal ID="Literal7" runat="server" Text="Please enter Supervisor ID: "></asp:Literal>
                                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" ControlToValidate="TextBox5" ForeColor="Red"></asp:RequiredFieldValidator>
                            </li>
                            <li class="list-group-item">
                                <asp:Button ID="Button10" CssClass="m-2 btn btn-danger" runat="server" Text="Continue" OnClick="ContinueButton_Click" />
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div id="OperationWindow" runat="server">
            <asp:GridView ID="OtherGridView" CssClass="table table-bordered table-hover table-sm table-info" runat="server" AutoGenerateColumns="True">
            </asp:GridView>
            <!-- Thesis edit GridView -->
            <asp:GridView ID="GridView" CssClass="table table-bordered table-hover table-sm table-info" runat="server" AutoGenerateColumns="False">
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

            <div class="container card bg-info p-3">
                <!-- Table for thesis edit -->
                <div class="col card bg-opacity-75">
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

                                <asp:CheckBox ID="Co_supervisorCheckBox" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="Co_supervisorCheckBox_CheckedChanged" />

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
                </div>
                <div class="col card bg-opacity-75">
                    <asp:RadioButtonList ID="rblOptions" runat="server" OnSelectedIndexChanged="rblOptions_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Text="Edit" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Delete" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                    <div class="d-grid d-md-flex justify-content-md-center">
                        <asp:Button ID="EditButton" CssClass="m-2 btn btn-danger" runat="server" OnClick="EditButton_Click" Text="Finish" />
                    </div>
                </div>
            </div>
        </div>

        <h2 class="h2 font-italic">Thesis Overview</h2>
        <asp:GridView ID="SelectionGridView" CssClass="table table-bordered table-hover table-sm table-info" runat="server"></asp:GridView>

    </form>
</body>
</html>
