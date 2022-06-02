<%@ Page Title="DBA Website: Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="DBAWebsite._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Welcome to Datbase Administration! 
    </h2>
    <%--<h3>DO's:
    </h3>
    <ul>
        <li>PATIENCE</li>
        <li>PRIORITIZE</li>
        <li>TEAM PLAYER</li>
        <li>CHAIN OF COMMAND</li>
    </ul>
    <h3>DONT'S:
    </h3>
    <ul>
        <li>SA ACCESS WITHOUT MANAGERS APPROVAL</li>
    </ul>--%>
    <div style="width: 800px; height: 500px; overflow: hidden; text-align:center;margin-left:105px;margin-bottom:50px;margin-top:50px;">
        <img id="Img2" runat="server" src="~/Images/database.jpg" align="middle"/>
    </div>
</asp:Content>
