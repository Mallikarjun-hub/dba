<%@ Page Title="BuildQAComparision" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuildQAComparisonReport.aspx.cs" Inherits="DBAWebsite.BuildQAComparisonReport" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2 style="text-align: center;">Build/QA Comparison Report for Server: 
        <asp:Label ID="lblhead_servername" runat="server"></asp:Label></h2>
    <br />
    <br />

    <div id="container" style="width: 100%; margin-bottom: 500px;">
        <div id="noneditablepane_left" style="float: left; width: 100%; line-height: 3.5em;">
            <table>
                <tr>
                    <td valign="top" style="width:300px;">
                        <label for="resource_name"><b>Resource Name</b></label>
                    </td>
                    <td valign="top" style="width:300px;">
                        <asp:Label ID="ldlbuild_ResourceName" runat="server"></asp:Label>
                    </td>
                    <td valign="top" style="width:300px;">
                        <asp:Label ID="ldlqa_ResourceName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="dbadb_create"><b>_DBADb created</b></label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlbuild_dbadb" runat="server"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlqa_dbadb" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="memory_capped"><b>Memory Capped</b></label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlbuild_memoryCapped" runat="server"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlqa_memoryCapped" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="Initial_backup"><b>Initial Backup</b></label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlbuild_initialBackup" runat="server"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlqa_initialBackup" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="backup_scheduled"><b>Backup Scheduled</b></label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlbuild_backupSchedule" runat="server"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlqa_backupSchedule" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="expected_golivedate"><b>Expected Go Live Date</b></label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlbuild_goliveDate" runat="server"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlqa_goliveDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="drive_layout"><b>Follow Drive Layout</b></label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlbuild_drivelayout" runat="server"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlqa_drivelayout" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="sql_version"><b>SQL Version</b></label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlbuild_sqlVersion" runat="server"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlqa_sqlVersion" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="monitor_tool"><b>Monitoring Tool</b></label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlbuild_monitorTool" runat="server"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlqa_monitorTool" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="high_availability"><b>High Availablity</b></label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlbuild_highAvailability" runat="server"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlqa_highAvailability" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="processors_core_acknowledge"><b>No of Processors and Cores</b></label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlbuild_processorscores" runat="server"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlqa_processorscores" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <label for="mail_setup"><b>Mail Setup</b></label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlbuild_mailsetup" runat="server"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="ldlqa_mailsetup" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div style="text-align: center">
        <table>
            <tr style="height: 50px">
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Button Text="Compare" OnClick="btn_compare_Click" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <p>
            <asp:Label ID="lbl_compare_results" runat="server" Font-Bold="true" ForeColor="RoyalBlue" Style="text-align: right"></asp:Label>
        </p>
    </div>
    <div style="margin: 10px 0; text-align: left; margin-bottom: 50px">
        <p>
            <asp:Button Text="Submit" OnClick="btn_send_Click" runat="server" />
        </p>
    </div>


</asp:Content>
