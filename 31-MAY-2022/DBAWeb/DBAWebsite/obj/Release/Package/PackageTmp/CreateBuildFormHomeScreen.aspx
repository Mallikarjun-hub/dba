<%@ Page Title="CreateBuildFormHomeScreen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateBuildFormHomeScreen.aspx.cs" Inherits="DBAWebsite.CreateBuildHomeScreen" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <br />
    <h2 style="text-align: center;">Create Build Form Home Screen</h2>
    <br />
    <br />
    <br />
    <br />

    <div>
        <table width="50%">
            <tr>
                <td>
                    <label for="build_select_server"><b>Select ServerName:</b></label>
                 </td>
            
                <td>
                    <asp:DropDownList ID="build_homescreen_Server_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value" >
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
