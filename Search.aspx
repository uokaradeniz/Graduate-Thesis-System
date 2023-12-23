<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Graduate_Thesis_System.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">

    <title>Search Thesis | Graduate Thesis System</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="h1 alert-warning text-center p-2">Search Thesis</h1>
        <div id="SelectionWindow" style="margin-top: 20%;" class="col-12 d-flex justify-content-center align-items-center" runat="server">
            <asp:Literal ID="Literal1" runat="server" Text="Search for a thesis by word: "></asp:Literal>
            <asp:TextBox ID="SearchTextBox" runat="server" CausesValidation="True"></asp:TextBox>
            <asp:DropDownList ID="SearchDropDownList" Visible="true" runat="server" OnSelectedIndexChanged="SelectDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            <asp:DropDownList ID="SelectDropDownList" Visible="false" runat="server" AutoPostBack="True"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvInput" runat="server"
                ControlToValidate="SearchTextBox"
                ErrorMessage="Atleast 1 character is required."
                Display="Dynamic" ForeColor="Red">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                ControlToValidate="SearchTextBox"
                ValidationExpression="^.{1,}$"
                ErrorMessage="Atleast 1 character is required."
                Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Button ID="ContinueButton" CssClass="m-2 btn btn-danger" runat="server" Text="Continue" OnClick="ContinueButton_Click" />
            <asp:Button ID="BackButton" CssClass="m-2 btn btn-danger" runat="server" Text="Back" OnClick="BackButton_Click" CausesValidation="False" />
        </div>

        <asp:GridView ID="GridView1" CssClass="table-bordered table-hover" runat="server" AutoGenerateColumns="false">
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
    </form>
</body>
</html>
