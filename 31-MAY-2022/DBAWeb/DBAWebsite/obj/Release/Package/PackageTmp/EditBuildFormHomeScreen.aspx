<%@ Page Title="EditBuildFormHomeScreen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBuildFormHomeScreen.aspx.cs" Inherits="DBAWebsite.EditBuildFormHomeScreen" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <br />
    <h2 style="text-align: center;">Edit Build Form Home Screen</h2>
    <br />
    <br />
    <br />
    <br />

    <div>
        <table width="50%">
            <tr>
                <td>
                    <label for="edit_build_select_server"><b>Select ServerName:</b></label>
                 </td>
            
                <td>
                    <asp:DropDownList ID="build_homescreen_Server_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value" >
                        <asp:ListItem> </asp:ListItem>
                    </asp:DropDownList>                    
                </td>                    
            
                <td>
                    <asp:Button ID="build_myBtn" runat="server" Text="Edit Server" onclick="myBtn_Click" />                    
                </td>
            </tr>
        </table>          
    </div>
</asp:Content>

