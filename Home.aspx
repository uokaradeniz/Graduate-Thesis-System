<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Graduate_Thesis_System.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home | Graduate Thesis System</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar alert-warning mb-3">
            <h1 class="h1 navbar-text text-primary" style="text-align: center;">
                <img style="width: 75px" src="Logo.png" />
                Graduate Thesis System</h1>
            <h2 class="h2 navbar-text text-primary" style="text-align: center;">
                <img style="width: 50px" src="HomeLogo.png" />Home</h2>
            <div class="d-flex justify-content-center p-3 card-header bg-white bg-opacity-50 border border-warning rounded">
                <asp:Button ID="HomeButton" runat="server" Text="Home" CssClass="m-2 btn btn-info" Width="200px" OnClick="HomeButton_Click" />
                <asp:Button ID="EditDeleteButton" runat="server" Text="Edit | Delete" CssClass="m-2 btn btn-info" Width="200px" OnClick="EditDeleteButton_Click" />
                <asp:Button ID="SubmitButton" runat="server" Text="Submission" CssClass="m-2 btn btn-info" Width="200px" OnClick="SubmitButton_Click" />
                <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="m-2 btn btn-info" Width="200px" OnClick="SearchButton_Click" />
            </div>
        </nav>

        <div class="ms-2 me-2">
            <h2 class="h2 font-italic">Thesis List</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table-bordered table-hover table-sm table-info">
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
        </div>
    </form>
</body>
</html>
