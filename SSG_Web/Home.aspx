<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SSG_Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bindle</title>
    <link href="~/Content/SSG-styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="SSG-webform">
            <asp:Label ID="lblBookName" runat="server" CssClass ="SSG-label">Book</asp:Label>
            <br />
            <asp:TextBox ID ="txtBookName" runat="server" CssClass="SSG-textbox"></asp:TextBox>
            <br />
            <asp:Button ID="btnSearch" runat="server" text="Search" CssClass="SSG-button" OnClick="btnSearch_Click"/>
            <br />
            <br />
            <asp:Label ID="lblBooks" runat="server" CssClass ="SSG-label">Select Book</asp:Label>
            <asp:ListBox ID="lbBooksResult" runat="server" CssClass="SSG-listbox" OnSelectedIndexChanged="lbBooksResult_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="lblChapters" runat="server" CssClass ="SSG-label">Chapters</asp:Label>
            <asp:ListBox ID="lbChaptersResult" runat="server" CssClass="SSG-listbox"></asp:ListBox>
        </div>
    </form>
</body>
</html>
