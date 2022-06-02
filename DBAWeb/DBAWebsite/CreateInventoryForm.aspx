<%@ Page Title="CreateInventoryForm" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateInventoryForm.aspx.cs" Inherits="DBAWebsite.CreateInventory" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2 style="text-align: center;">Create Inventory Form for Server: <asp:Label ID="lblhead_servername" runat="server"></asp:Label></h2>
    <br />
    <span class="failureNotification">* Denotes  Required Field</span>
    <br />
    <br />

    <form id="htmlform" method="post" action="Web.config">
        <div style="line-height: 3.0em;">
            <table width="1000px">
                <tr>
                    <td valign="top" style="width:200px;">
                        <label for="Inventory_Number"><b>Inventory Number</b></label>
                    </td>
                    <td valign="top" style="width:300px;">
                        <asp:Label ID="Inventory_Number_autovalue" runat="server"></asp:Label>
                    </td>
                    <td valign="top" align="center" style="width:300px;">
                        <label for="Comments "><b>Comments </b></label>
                    </td>
                </tr>

                <tr>
                    <td valign="top">
                        <label for="server_name"><b>Server Name</b></label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="lbl_servername" runat="server"></asp:Label>
                    </td>
                    <td valign="top">
                        <textarea id="inv_servername_notes" name="inv_servername_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>

                <tr>
                    <td valign="top">
                        <label for="Inventory_type"><b>Inventory Type *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="Inventory_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td valign="top">
                        <textarea id="inv_inventorytype_notes" name="inv_inventorytype_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>

                <tr>
                    <td valign="top">
                        <label for="helpdeskid"><b>Help desk ID</b></label>
                    </td>
                    <td valign="top">
                         <asp:TextBox maxlength="80" size="30" ID="txt_helpdeskid" runat="server"/>
                    </td>

                    <td valign="top">
                        <textarea id="inv_helpdeskid_notes" name="inv_helpdeskid_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="projectid"><b>Project ID</b></label>
                    </td>
                    <td valign="top">
                        <asp:TextBox maxlength="80" size="30" ID="txt_projectid" runat="server"/>
                    </td>

                    <td valign="top">
                        <textarea id="inv_projectid_notes" name="inv_projectid_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="Location"><b>Location *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="Location_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td valign="top">
                        <textarea id="inv_location_notes" name="inv_location_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="location_id"><b>Location ID</b></label>
                    </td>                    
                    <td valign="top">
                        <asp:DropDownList ID="location_id_dropdownlist" runat="server" AppendDataBoundItems="true"  DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <textarea id="inv_locationid_notes" name="inv_locationid_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="environment"><b>Environment *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="Environment_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td valign="top">
                        <textarea id="inv_environment_notes" name="inv_environment_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="application_info"><b>Application Info *</b></label>
                    </td>
                     <td valign="top">
                        <asp:DropDownList ID="application_info_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td valign="top">
                        <textarea id="inv_applicationinfo_notes" name="inv_applicationinfo_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="ITcontact_team"><b>IT Contact Team *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="ITcontact_team_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td valign="top">
                        <textarea id="inv_itcontactteam_notes" name="inv_itcontactteam_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="ITcontact_person"><b>IT Contact Person *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="ITcontact_person_dropdownlist" runat="server" AppendDataBoundItems="true"  DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td valign="top">
                        <textarea id="inv_itcontactperson_notes" name="inv_itcontactperson_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="Business_contact"><b>Business Contact *</b></label>
                    </td>
                     <td valign="top">
                        <asp:DropDownList ID="Business_contact_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td valign="top">
                        <textarea id="inv_businesscontact_notes" name="inv_businesscontact_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="sox_complaint"><b>SOX Complaince *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="sox_complaint_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td valign="top">
                        <textarea id="inv_soxcomplaint_notes" name="inv_soxcomplaint_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="backup_type"><b>Backup Type *</b></label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="backup_type_dropdownlist" runat="server" AppendDataBoundItems="true" DataTextField="key" DataValueField="value">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td valign="top">
                        <textarea id="inv_backuptype_notes" name="inv_backuptype_notes" cols="40" rows="1"></textarea>
                    </td>
                </tr>
                <%--<tr>
                    <td valign="top">
                        <label for="Comments "><b>Overall Inventory Notes </b></label>
                    </td>
                    <td valign="top">
                        <textarea name="Notes " cols="25" rows="6"></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <input type="submit" value="Submit" />
                    </td>
                </tr>--%>
            </table>
             <div>
                <table width="1000px">
                    <tr>
                        <td valign="top">
                            <label for="notes"><b>Overall Inventory Notes</b></label>
                        </td>
                        <td>
                            <textarea id="inv_overall_notes" name="inv_overall_notes" cols="62" rows="6"></textarea>
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
