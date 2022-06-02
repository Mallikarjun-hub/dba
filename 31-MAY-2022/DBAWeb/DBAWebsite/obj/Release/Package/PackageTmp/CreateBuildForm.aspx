<%@ Page Title="CreateBuildForm" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateBuildForm.aspx.cs" Inherits="DBAWebsite.CreateBuild"  EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2 style="text-align: center;">Create Build Form for Server: 
        <asp:Label ID="lblhead_servername" runat="server"></asp:Label></h2>
    <br />

    <form class="htmlform" method="post" action="Web.config">
        <div id="noneditablepane" style="line-height: 2.0em;">            
            <fieldset>
                <legend>Server Details - Auto Completed</legend>
                <table width="90%">
                    <tr>
                        <td valign="top">
                            <label for="Inventory_Number"><b>Inventory Number :</b></label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="Inventory_Number_autovalue" runat="server"></asp:Label>
                        </td>
                        <td valign="top">
                            <label for="Server_name" id="serverid1"><b>Server Name :</b></label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="Server_name_autovalue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <label for="Server_Memory"><b>Server Memory :</b></label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="Server_Memory_autovalue" runat="server"></asp:Label>
                        </td>
                        <td valign="top">
                            <label for="SQL_Memory"><b>SQl Memory :</b></label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="SQL_Memory_autovalue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <label for="drive_layout"><b>Drive Layout :</b></label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="drive_layout_autovalue" runat="server"></asp:Label>
                        </td>
                        <td valign="top">
                            <label for="install_date"><b>Install Date :</b></label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="install_date" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <label for="processors_count"><b>No.of processors :</b></label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="processors_count_autovalue" runat="server"></asp:Label>
                        </td>
                        <td valign="top">
                            <label for="cores_count"><b>No.of cores :</b></label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="cores_count_autovalue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <label for="dbadb"><b>DBADB :</b></label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="dbadb_autovalue" runat="server"></asp:Label>
                        </td>
                        <td valign="top">
                            <label for="Service_account"><b>Service Account :</b></label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="Service_account_autovalue" runat="server"></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td valign="top">
                            <label for="backup_type"><b>Backup type :</b></label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="backup_type_autovalue" runat="server"></asp:Label>
                        </td>
                        <td valign="top">
                            <label for="sql_version"><b>SQL version :</b></label>
                        </td>
                        <td valign="top">
                            <asp:Label ID="sql_version_autovalue" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div id="editablepane" style="line-height: 3.5em;">
            <table width="1000px">
                <tr>
                    <td valign="top" style="width:200px;">
                        <label for="resource_name"><b>Resource Name *</b></label>
                    </td>
                    <td valign="top" style="width:300px;">
                        <asp:DropDownList ID="Resource_name_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top" style="width:300px;">
                        <textarea id="bld_resource_notes" name="bld_resource_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="dbadb_create"><b>_DBADb created *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="dbadb_create_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_dbadb_notes" name="bld_dbadb_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="memory_capped"><b>Memory Capped *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="memory_capped_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_memorycapped_notes" name="bld_memorycapped_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="Initial_backup"><b>Initial Backup *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="Initial_backup_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_initialbackup_notes" name="bld_initialbackup_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="backup_scheduled"><b>Backup Scheduled *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="backup_scheduled_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_backupscheduled_notes" name="bld_backupscheduled_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="expected_golivedate"><b>Expected Go Live Date *</b></label>
                    </td>
                    <td valign="top">
                        <input type="text" id="txtDate_build" name ="txtDate_build"  Style="width: 100px;" />  
                        <input id="inpHide_build" type="hidden" runat="server" />                                                
                    </td>
                    <td valign="top">
                        <textarea id="bld_golivedate_notes" name="bld_golivedate_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="drive_layout"><b>Follow Drive Layout *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="drive_layout_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_drivelayout_notes" name="bld_drivelayout_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="sql_version"><b>SQL Version *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="sql_version_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_sqlversion_notes" name="bld_sqlversion_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="monitor_tool"><b>Monitoring Tool *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="monitor_tool_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_monitortool_notes" name="bld_monitortool_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="high_availability"><b>High Availablity *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="high_availability_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_highavailability_notes" name="bld_highavailability_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="processors_core_acknowledge"><b>No of Processors and Cores *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="processors_core_acknowledge_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_processoracknowledge_notes" name="bld_processoracknowledge_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="mail_setup"><b>Mail Setup *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="mail_setup_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="bld_mail_setup_notes" name="bld_mail_setup_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <%--<tr>
                    <td valign="top">
                        <label for="notes"><b>Overall Build Notes</b></label>
                    </td>
                    <td valign="top">
                        <textarea id="bld_overall_notes" name="bld_overall_notes" cols="45" rows="6"></textarea>
                    </td>
                </tr>--%>
                <%--<tr>
                    <td colspan="2" style="text-align: center">
                        <input type="submit" value="Submit" onclick="submit_Click" runat="server"/>
                    </td>
                </tr>--%>
            </table>
            <div>
                <table width="1000px">
                    <tr>
                        <td valign="top">
                            <label for="notes"><b>Overall Build Notes</b></label>
                        </td>
                        <td>
                            <textarea id="bld_overall_notes" name="bld_overall_notes" cols="62" rows="6"></textarea>
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


    <%--<asp:Label ID="InventoryIdLabel" runat="server">Inventory Number:</asp:Label>
    <asp:Label ID="InventoryIdAutofillLabel" runat="server"></asp:Label>

    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
    </p>   --%>
</asp:Content>
