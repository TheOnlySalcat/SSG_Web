<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SSG_Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bindle</title>
    <link href="~/Content/SSG-styles.css" rel="stylesheet" type="text/css" />
</head>
<body class="SSG-body">
    <header class="SSG-titlebar">
        <h1 class="SSG-header">LOTR Enthusiast App</h1>
    </header>
    <form id="form1" runat="server">
        <div class="SSG-row">
            <div class="SSG-titlecolumn1">
                <asp:Label ID="lblBookMovieHeader" runat="server" CssClass ="SSG-label" style="display:flex; justify-content:center; font-size:18px; background-color:#99c7ff">Search by Book or Movie</asp:Label>
            </div>
            <div class="SSG-titlecolumn2">
                <asp:Label ID="lblCharacterHeader" runat="server" CssClass ="SSG-label" style="display:flex; justify-content:center; font-size:18px; background-color:#82baff">Search by Character</asp:Label>
            </div>
        </div>
        <div class="SSG-row">
            <div class="SSG-column" style="margin: auto; align-items:center; justify-content:center;">
                <asp:Label ID="lblBookName" runat="server" CssClass ="SSG-label">Book or Movie name</asp:Label>
                <br />
                <asp:TextBox ID ="txtBookName" runat="server" CssClass="SSG-textbox"></asp:TextBox>
                <br />
                <asp:Button ID="btnSearch" runat="server" text="Search" CssClass="SSG-button" OnClick="btnSearch_Click"/>
                <br />
                <br />
                <asp:Label ID="lblBooks" runat="server" CssClass ="SSG-label">Select Book</asp:Label>
                <br />
                <asp:ListBox ID="lbBooksResult" runat="server" CssClass="SSG-listbox" OnSelectedIndexChanged="lbBooksResult_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                <br />
                <br />
                <asp:Label ID="lblChapters" runat="server" CssClass ="SSG-label">Chapters</asp:Label>
                <br />
                <asp:ListBox ID="lbChaptersResult" runat="server" CssClass="SSG-listbox SSG-listboxtall"></asp:ListBox>
            </div>
            <div class="SSG-column">
                <asp:Label ID="lblMovies" runat="server" CssClass ="SSG-label">Movies</asp:Label>
                <br />
                <asp:ListBox ID="lbMoviesResult" runat="server" CssClass="SSG-listbox" style="height:150px;" OnSelectedIndexChanged="lbMoviesResult_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                <br />
                <br />
                <asp:Label ID="lblQuotes" runat="server" CssClass ="SSG-label">Quotes</asp:Label>
                <br />
                <asp:ListBox ID="lbQuotesResult" runat="server" CssClass="SSG-listbox" style="height:150px;" OnSelectedIndexChanged="lbQuotesResult_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                <br />
                <br />
                <asp:Label ID="lblCharacters" runat="server" CssClass ="SSG-label">Quote Character</asp:Label>
                <br />
                <asp:TextBox ID="txtCharactersResult" ReadOnly="true" runat="server" CssClass="SSG-textbox"></asp:TextBox>
            </div>
            <div class="SSG-column">
                <asp:Label ID="lblSearchCharacters" runat="server" CssClass="SSG-label">Character Name</asp:Label>
                <br />
                <asp:TextBox ID="txtSearchCharacter" runat="server" CssClass="SSG-textbox"></asp:TextBox>
                <br />
                <asp:Button ID="btnCacheCharacters" runat="server" CssClass="SSG-button" text="Search" OnClick="btnCacheCharacters_Click"/>
                <br />
                <br />
                <asp:ListBox ID="lbCachedCharacters" runat="server" CssClass="SSG-listbox" style="height:200px" OnSelectedIndexChanged="lbCachedCharacters_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                <br />
            </div>
            
        </div>
        
    </form>
    <footer class="SSG-footermain">
        <p>
            Developed by <a href="mailto:notputtingmyrealemailhere@gmail.com">Scott Nicol</a> November 2020
        </p>
        <p>
            <b>Things which could be done to enhance solution further:</b>
            <br />- Add functionality to display & search by character characteristics
            <br />- Add link to imdb for movies (possibly in an iframe)
            <br />- Add extract to file functionality, but what information would be useful to the user?
            <br />- Further UI enhancements
            <br />- Add forum type functionality for enthusiasts to connect (realistically social media would be king here)
        </p>
        <p>
            <b>Notes about the solution:</b>
            <br />I started with an MVP in winforms and then converted to equivalent MVP in asp.NET
            <br />The web MVP was then further enhanced to simulate agile/ CD project delivery
            <br />
            <br />Styling was built from scratch but would be significantly better with a proper HTML builder
        </p>
    </footer>
</body>
</html>
