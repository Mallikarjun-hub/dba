<%@ Page Title="GoLiveCheckListForm" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GoLiveCheckListForm.aspx.cs" Inherits="DBAWebsite.GoLiveCheckListForm" EnableEventValidation="false"%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2 style="text-align: center;">GoLive Checklist Form for Server: <asp:Label ID="lblhead_servername" runat="server"></asp:Label></h2>
    <br />
    <%--<span class="failureNotification">* Denotes  Required Field</span>--%>
    <br />
    <br />

    <form id="htmlform" method="post" action="Web.config">
        <div style="line-height: 3.0em;">
            <table width="1000px">
                <tr>
                    <td valign="top" style="width:300px;">
                        <label for="objectExecution_permissions"><b>Object Execution Permissions</b></label>                        
                    </td>
                    <td valign="top" style="width:600px;">
                        <asp:CheckBox ID="chk_defaultdb" Text="<b>Default DB</b>" runat="server"/>
                        <asp:CheckBox ID="chk_serverroles" Text="<b>Server Roles</b>" runat="server"/>
                        <asp:CheckBox ID="chk_usermappings" Text="<b>User Mapping Database</b>" runat="server"/>
                        <asp:CheckBox ID="chk_passwordsave" Text="<b>PasswordSave</b>" runat="server"/>
                    </td>
                </tr>
            </table>
        </div>
        <div style="line-height: 3.0em;">
            <table width="1000px">                
               <tr>
                    <td valign="top" style="width:300px;">
                        <label for="resource_name"><b>Resource Name</b></label>
                    </td>
                    <td valign="top" style="width:200px;">
                        <asp:DropDownList ID="Resource_name_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top" style="width:250px;">
                        <textarea id="bld_resource_notes" name="bld_resource_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>                 
                              
                <tr>
                    <td valign="top">
                        <label for="linked_servers"><b>Linked Servers</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="linked_servers_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_linked_servers_notes" name="bld_linked_servers_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="odbc"><b>ODBC</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="odbc_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_odbc_notes" name="bld_odbc_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="client_info"><b>Oracle client/AS400 Client</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="client_info_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_client_info_notes" name="bld_client_info_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="compatability_mode"><b>Compatability Mode</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="compatability_mode_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_compatability_mode_notes" name="bld_compatability_mode_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>                
                <tr>
                    <td valign="top">
                        <label for="database_mode"><b>DataBase Mode</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="database_mode_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_database_mode_notes" name="bld_database_mode_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="backup_info"><b>Backups/Commvault/Right Storage</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="backup_info_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_backup_info_notes" name="bld_backup_info_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="maintenance_job"><b>Maintenance Job </b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="maintenance_job_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_maintenance_job_notes" name="bld_maintenance_job_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="monitoring_tools"><b>Monitoring tools (SCOM/Manage Engine)</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="monitoring_tools_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_monitoring_tools_notes" name="bld_monitoring_tools_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="highavailability_info"><b>HA/DR (Mirroring, Always on, log shipping)</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="highavailability_info_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_highavailability_info_notes" name="bld_highavailability_info_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="dba_domain"><b>DBA domain update (update/Decommision)</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="dba_domain_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_dba_domain_notes" name="bld_dba_domain_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="ssis_info"><b>SSIS/SSRS/SSAS</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="ssis_info_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_ssis_info_notes" name="bld_ssis_info_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                 <tr>
                    <td valign="top">
                        <label for="memory_settings"><b>Memory settings</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="memory_settings_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_memory_settings_notes" name="bld_memory_settings_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
            </table>
             <div>
                <table width="1000px">
                    <tr>
                        <td valign="top">
                            <label for="notes"><b>Overall Inventory Notes</b></label>
                        </td>
                        <td>
                            <textarea id="inv_overall_notes" name="bld_overall_notes" cols="62" rows="6"></textarea>
                        </td>
                        <td>

                        </td>
                    </tr>
                </table>                
            </div>
            <div style="text-align:center">
                <asp:Button Text="Submit" onclick="submit_Click" runat="server"/>
            </div>                        
        </div>
    </form>
</asp:Content>
