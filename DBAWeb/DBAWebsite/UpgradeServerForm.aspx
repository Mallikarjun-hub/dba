<%@ Page Title="UpgradeServerForm" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpgradeServerForm.aspx.cs" Inherits="DBAWebsite.UpgradeServerForm" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2 style="text-align: center;">Upgrade Form for Server : 
        <asp:Label ID="lblhead_servername" runat="server"></asp:Label></h2>
    <br />

    <form class="ugradeserverform" method="post" action="Web.config">
        <div id="noneditablepane_upgrade_old" style="line-height: 2.0em;">            
            <fieldset>
                <legend>Old Server Details - Auto Completed</legend>
                <table>
                    <tr>                        
                        <td valign="top" style="width: 100px;">
                            <label for="Server_name" id="upgrade_server"><b>Server Name :</b></label>
                        </td>
                        <td valign="top" style="width: 300px;">
                            <asp:Label ID="upgrade_Server_autovalue" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="width: 200px;">
                            <label for="Server_name" id="upgrade_server_version"><b>DB version :</b></label>
                        </td>
                        <td valign="top" style="width: 300px;">
                            <asp:Label ID="upgrade_version_autovalue" runat="server"></asp:Label>
                        </td>
                        </tr>
                    <tr>
                        <td valign="top" style="width: 200px;">
                            <label for="Server_name" id="upgrade_server_processors"><b>Number of Processors :</b></label>
                        </td>
                        <td valign="top" style="width: 100px;">
                            <asp:Label ID="upgrade_processors_autovalue" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="width: 200px;">
                            <label for="Server_name" id="upgrade_server_cores"><b>Number of Cores :</b></label>
                        </td>
                        <td valign="top" style="width: 100px;">
                            <asp:Label ID="upgrade_cores_autovalue" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                    </table>
                </fieldset>
            </div>
        <div id="noneditablepane_upgrade_new" style="line-height: 2.0em;">            
            <fieldset>
                <legend>New Server Details - Auto Completed</legend>
                <table>
                    <tr>                        
                        <td valign="top" style="width: 100px;">
                            <label for="Server_name" id="upgrade_server_new"><b>Server Name :</b></label>
                        </td>
                        <td valign="top" style="width: 300px;">
                            <asp:Label ID="upgrade_Server_new_autovalue" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="width: 200px;">
                            <label for="Server_name" id="upgrade_server_version_new"><b>DB version :</b></label>
                        </td>
                        <td valign="top" style="width: 300px;">
                            <asp:Label ID="upgrade_version_new_autovalue" runat="server"></asp:Label>
                        </td>
                        </tr>
                    <tr>
                        <td valign="top" style="width: 200px;">
                            <label for="Server_name" id="upgrade_server_processors_new"><b>Number of Processors :</b></label>
                        </td>
                        <td valign="top" style="width: 100px;">
                            <asp:Label ID="upgrade_processors_new_autovalue" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="width: 200px;">
                            <label for="Server_name" id="upgrade_server_cores_new"><b>Number of Cores :</b></label>
                        </td>
                        <td valign="top" style="width: 100px;">
                            <asp:Label ID="upgrade_cores_new_autovalue" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td valign="top" style="width: 200px;">
                            <label for="Server_name" id="upgrade_server_memory_new"><b>Server Memory :</b></label>
                        </td>
                        <td valign="top" style="width: 100px;">
                            <asp:Label ID="upgrade_servermemory_autovalue" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="width: 200px;">
                            <label for="Server_name" id="upgrade_sql_memory_new"><b>SQL Memory :</b></label>
                        </td>
                        <td valign="top" style="width: 100px;">
                            <asp:Label ID="upgrade_sqlmemory_autovalue" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                    </table>
                </fieldset>
            </div>

        <div id="editablepane" style="line-height: 3.5em;">
            <table width="1000px">
                <tr>
                    <td valign="top" style="width:100px;">
                        <label for="server_name"><b>Server Name </b></label>
                    </td>
                    <td valign="top" style="width:100px;">
                        <asp:DropDownList ID="Server_name_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top" style="width:300px;">
                        <textarea id="servername_notes" name="servername_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="upgradedate"><b>Upgrade Date *</b></label>
                    </td>
                    <td valign="top">
                        <input type="text" id="SQLupgradeDate" name ="SQLupgradeDate"  Style="width: 100px;" />  
                        <input id="inpHide_upgrade" type="hidden" runat="server" />                                                
                    </td>
                    <td valign="top">
                        <textarea id="upgrade_date_notes" name="upgrade_date_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="server_memory"><b>Server Memory</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="server_memory_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="upgrade_servermemory_notes" name="upgrade_servermemory_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="sql_memory"><b>SQL Memory</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="sql_memory_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="upgrade_sqlmemory_notes" name="upgrade_sqlmemory_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="noofprocessors"><b>No.of Processors</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="noofprocessors_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="upgrade_noofprocessors_notes" name="upgrade_noofprocessors_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="noofcores"><b>No.of Cores</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="noofcores_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="upgrade_noofcores_notes" name="upgrade_noofcores_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="sql_version"><b>SQL Version</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="sqlversion_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>                                              
                    </td>
                    <td valign="top">
                        <textarea id="upgrade_sqlversion_notes" name="upgrade_sqlversion_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr> 
                <tr>
                    <td valign="top">
                        <label for="compatability"><b>Compatability Check</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="compatability_DropDownList" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>                                              
                    </td>
                    <td valign="top">
                        <textarea id="upgrade_compatability_notes" name="upgrade_compatability_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>                  
                </table>
            </div>
        </form>

     <div style="text-align: center;line-height: 4.0em;">
                <asp:Button ID="submit_myBtn" Text="Submit" onclick="myBtn_Click" runat="server"/>
        </div>
</asp:Content>