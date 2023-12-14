﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Graduate_Thesis_System.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home | Graduate Thesis System</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <nav class="alert-warning">
            <h1 style="text-align:center;">Graduate Thesis System</h1>
            <div class="d-flex justify-content-center p-3">
                <asp:Button ID="EditButton" runat="server" Text="Edit/Delete" CssClass="m-2 btn btn-danger" Width="200px" OnClick="EditButton_Click"/>
                <asp:Button ID="SubmitButton" runat="server" Text="Submission" CssClass="m-2 btn btn-danger"  Width="200px" OnClick="SubmitButton_Click"/>
                <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="m-2 btn btn-danger"  Width="200px"/>
            </div>
        </nav>

        <div class="m-5">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table-bordered table-hover">
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