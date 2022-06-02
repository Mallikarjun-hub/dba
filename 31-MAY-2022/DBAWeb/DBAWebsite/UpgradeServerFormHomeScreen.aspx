<%@ Page Title="UpgradeServerFormHomeScreeen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpgradeServerFormHomeScreen.aspx.cs" Inherits="DBAWebsite.UpgradeServerFormHomeScreen" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <br />
    <h2 style="text-align: center;">Upgrade Server Form Home Screen</h2>
    <br />
    <br />
    <br />
    <br />

    <div style="line-height: 4.0em;">
        <table width="60%">
            <tr>
                <td>
                    <label for="upgrade_select_oldserver"><b>Select Old ServerName:</b></label>
                 </td>
            
                <td>
                    <asp:DropDownList ID="upgrade_homescreen_oldServer_dropdownlist" runat="server" AppendDataBoundItems="true"  DataTextField="key" DataValueField="value" >
                        <asp:ListItem> </asp:ListItem>
                    </asp:DropDownList>                    
                </td>                    
                           
            </tr>
            <tr>
                <td>
                    <label for="upgrade_select_newserver"><b>Select New ServerName:</b></label>
                 </td>
            
                <td>
                    <asp:DropDownList ID="upgrade_homescreen_newServer_dropdownlist" runat="server" AppendDataBoundItems="true"  DataTextField="key" DataValueField="value" >
                        <asp:ListItem> </asp:ListItem>
                    </asp:DropDownList>                    
                </td>   
                <td>
                    <asp:Button ID="upgrade_myBtn" runat="server" Text="Upgrade Server" onclick="myBtn_Click" />                                    
                </td>                                             
            </tr>
        </table>          
    </div>
   <%-- <div style="text-align: center;line-height: 5.0em;">
         <asp:Button ID="upgrade_myBtn" runat="server" Text="Upgrade Server" onclick="myBtn_Click" />                                    
    </div>--%>
</asp:Content>



