<%@ Page Title="CreateQAFormHomeScreen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateQAFormHomeScreen.aspx.cs" Inherits="DBAWebsite.CreateQAFormHomeScreen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <br />
    <h2 style="text-align: center;">Create QA Form Home Screen</h2>
    <br />
    <br />
    <br />
    <br />

    <div>
        <table width="50%">
            <tr>
                <td>
                    <label for="inventory_select_server"><b>Recently Updated Servers:</b></label>
                 </td>
            
                <td>
                    <asp:DropDownList ID="qa_homescreen_Server_dropdownlist" runat="server" AppendDataBoundItems="true"  DataTextField="key" DataValueField="value" >
                        <asp:ListItem> </asp:ListItem>
                    </asp:DropDownList>                    
                </td>      
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Create Server" onclick="myBtn_Click2" />                    
                </td>
           
                </tr>
            </table>
         <br />
    <br />
    <br />
  <%--  <br />--%>
        <table width="50%">
             <tr>
                <td>
                    <label for="build_select_server"><b>All Servers:</b></label>
                 </td>
            
                <td>
                    <asp:DropDownList ID="qa_homescreen_Server_fulldropdownlist" runat="server" AppendDataBoundItems="true"  DataTextField="key" DataValueField="value" >
                        <asp:ListItem> </asp:ListItem>
                    </asp:DropDownList>                    
                </td>    
                <td>
                    <asp:Button ID="build_myBtn" runat="server" Text="Create Server" onclick="myBtn_Click" />                    
                </td>
            </tr>
        </table>      
        
    </div>
    </asp:Content>
