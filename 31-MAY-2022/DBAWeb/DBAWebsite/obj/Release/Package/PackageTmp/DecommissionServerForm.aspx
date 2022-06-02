<%@ Page Title="DecommissionServerForm" Language="c#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="decommissionserverform.aspx.cs" Inherits="DBAWebsite.DecommissionServerForm" EnableEventValidation="false" %>

<asp:Content ID="content1" ContentPlaceHolderID="headcontent" runat="server">
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="maincontent" runat="server">
    <br />
    <h2 style="text-align: center;">Decommission Form for server: 
        <asp:Label ID="lblhead_servername" runat="server"></asp:Label></h2>
    <br />

    <div id="container" style="width: 100%; margin-bottom: 500px;">
        <div id="Decommissionpane" style="float: left; width: 100%; line-height: 3.5em;">
            <table>
                <tr>
                    <td valign="top" style="width: 200px;">
                        <label for="noofprocessors"><b>Number of Processors:</b></label>
                    </td>                    
                    <td valign="top" style="width: 100px;">
                        <asp:Label ID="lbldecommission_noofProcessors" runat="server"></asp:Label>
                    </td>
                    <td valign="top" style="width: 100px;">
                        <label for="confirmnoofprocessors"><b>Confirm:</b></label>
                    </td>
                    <td valign="top" style="width:100px;">
                        <asp:DropDownList ID="noofProcessors_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>                    
                </tr>
                <tr>
                    <td valign="top">
                        <label for="noofcores"><b>Number of cores:</b></label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="lbldecommission_noofcores" runat="server"></asp:Label>
                    </td>
                    <td valign="top">
                        <label for="confirmnoofcores"><b>Confirm:</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="noofcores_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="decommission_stopdate"><b>SQL Server Stop Date</b></label>
                    </td>
                    <td valign="top">
                        <input type="text" id="SQLstopDate" name ="SQLstopDate"  style="width: 100px;" />  
                        <input id="stopDate_Hide" type="hidden" runat="server" />                                                
                    </td>                    
                </tr>
                <tr>
                    <td valign="top">
                        <label for="decommission_uninstalldate"><b>SQL Server Uninstall Date</b></label>
                    </td>
                    <td valign="top">
                        <input type="text" id="SQLUninstallDate" name ="SQLUninstallDate"  style="width: 100px;" />  
                        <input id="uninstallDate_Hide" type="hidden" runat="server" />                                                
                    </td>                    
                </tr>
            </table>
        </div>

        <div style="text-align: center">
                <asp:Button Text="Submit" OnClick="submit_Click" runat="server"/>
        </div>
    </div>

   

</asp:Content>
