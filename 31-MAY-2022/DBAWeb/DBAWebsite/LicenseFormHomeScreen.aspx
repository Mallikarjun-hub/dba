<%@ Page Title="LicenseForm" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LicenseFormHomeScreen.aspx.cs" Inherits="DBAWebsite.LicenseFormHomeScreen" EnableEventValidation="false" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
   <br />
    <h2 style="text-align: center;">License Form Home Screen</h2>
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
                    <asp:DropDownList ID="license_homescreen_Server_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value" >
                        <asp:ListItem> </asp:ListItem>
                    </asp:DropDownList>                    
                </td>                    
            
                <td>
                    <asp:Button ID="license_myBtn" runat="server" Text="License Form" onclick="myBtn_Click" />                    
                </td>
            </tr>
        </table>          
    </div>
</asp:Content>
