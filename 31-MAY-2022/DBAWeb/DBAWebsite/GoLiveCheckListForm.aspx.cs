using DBAWebsite.APP;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBAWebsite
{
    public partial class GoLiveCheckListForm : System.Web.UI.Page
    {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    if (Application["Build_Server_Name"] != null)
                        lblhead_servername.Text = Application["Build_Server_Name"].ToString();

                    Resource_name_dropdownlist_DataBinding();
                    linked_servers_dropdownlist_DataBinding();
                    odbc_dropdownlist_DataBinding();
                    client_info_dropdownlist_DataBinding();
                    compatability_mode_dropdownlist_DataBinding();
                    database_mode_dropdownlist_DataBinding();
                    backup_info_dropdownlist_DataBinding();
                    maintenance_job_dropdownlist_DataBinding();
                    monitoring_tools_dropdownlist_DataBinding();
                    highavailability_info_dropdownlist_DataBinding();
                    dba_domain_dropdownlist_DataBinding();
                    ssis_info_dropdownlist_DataBinding();
                    memory_settings_dropdownlist_DataBinding();
                    
                }                  
            }


            protected void Resource_name_dropdownlist_DataBinding()
            {
                DataTable resourcename_info = new DataTable();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [Resource Name] FROM [dbo].[BuildScreen_Dropdown] WHERE [Resource Name] IS NOT NULL;", con);
                        adapter.Fill(resourcename_info);

                        Resource_name_dropdownlist.DataSource = resourcename_info;
                        Resource_name_dropdownlist.DataTextField = "Resource Name";
                        Resource_name_dropdownlist.DataValueField = "Resource Name";
                        Resource_name_dropdownlist.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "Error while binding drop down list");
                    }

                }
            }

            protected void linked_servers_dropdownlist_DataBinding()
            {
                DataTable linked_servers_info = new DataTable();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [golivechecklist_LinkedServers] FROM [dbo].[BuildScreen_Dropdown] WHERE [golivechecklist_LinkedServers] IS NOT NULL;", con);
                        adapter.Fill(linked_servers_info);

                        linked_servers_dropdownlist.DataSource = linked_servers_info;
                        linked_servers_dropdownlist.DataTextField = "golivechecklist_LinkedServers";
                        linked_servers_dropdownlist.DataValueField = "golivechecklist_LinkedServers";
                        linked_servers_dropdownlist.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "Error while binding drop down list");
                    }

                }
            }

            protected void odbc_dropdownlist_DataBinding()
            {
                DataTable odbc_dropdownlist_info = new DataTable();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [golivechecklist_odbc] FROM [dbo].[BuildScreen_Dropdown] WHERE [golivechecklist_odbc] IS NOT NULL;", con);
                        adapter.Fill(odbc_dropdownlist_info);

                        odbc_dropdownlist.DataSource = odbc_dropdownlist_info;
                        odbc_dropdownlist.DataTextField = "golivechecklist_odbc";
                        odbc_dropdownlist.DataValueField = "golivechecklist_odbc";
                        odbc_dropdownlist.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "Error while binding drop down list");
                    }

                }
            }

            protected void client_info_dropdownlist_DataBinding()
            {
                DataTable client_info_dropdown_info = new DataTable();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [golivechecklist_oracleclientInfo] FROM [dbo].[BuildScreen_Dropdown] WHERE [golivechecklist_oracleclientInfo] IS NOT NULL;", con);
                        adapter.Fill(client_info_dropdown_info);

                        client_info_dropdownlist.DataSource = client_info_dropdown_info;
                        client_info_dropdownlist.DataTextField = "golivechecklist_oracleclientInfo";
                        client_info_dropdownlist.DataValueField = "golivechecklist_oracleclientInfo";
                        client_info_dropdownlist.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "Error while binding drop down list");
                    }

                }
            }

            protected void compatability_mode_dropdownlist_DataBinding()
            {
                DataTable compatability_mode_info = new DataTable();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [golivechecklist_compatabilitymode] FROM [dbo].[BuildScreen_Dropdown] WHERE [golivechecklist_compatabilitymode] IS NOT NULL;", con);
                        adapter.Fill(compatability_mode_info);

                        compatability_mode_dropdownlist.DataSource = compatability_mode_info;
                        compatability_mode_dropdownlist.DataTextField = "golivechecklist_compatabilitymode";
                        compatability_mode_dropdownlist.DataValueField = "golivechecklist_compatabilitymode";
                        compatability_mode_dropdownlist.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "Error while binding drop down list");
                    }

                }
            }

            protected void database_mode_dropdownlist_DataBinding()
            {
                DataTable database_mode_info = new DataTable();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [golivechecklist_databasemode] FROM [dbo].[BuildScreen_Dropdown] WHERE [golivechecklist_databasemode] IS NOT NULL;", con);
                        adapter.Fill(database_mode_info);

                        database_mode_dropdownlist.DataSource = database_mode_info;
                        database_mode_dropdownlist.DataTextField = "golivechecklist_databasemode";
                        database_mode_dropdownlist.DataValueField = "golivechecklist_databasemode";
                        database_mode_dropdownlist.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "Error while binding drop down list");
                    }

                }
            }

            protected void backup_info_dropdownlist_DataBinding()
            {
                DataTable backup_info_dropdownlist_info = new DataTable();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [golivechecklist_backupInfo] FROM [dbo].[BuildScreen_Dropdown] WHERE [golivechecklist_backupInfo] IS NOT NULL;", con);
                        adapter.Fill(backup_info_dropdownlist_info);

                        backup_info_dropdownlist.DataSource = backup_info_dropdownlist_info;
                        backup_info_dropdownlist.DataTextField = "golivechecklist_backupInfo";
                        backup_info_dropdownlist.DataValueField = "golivechecklist_backupInfo";
                        backup_info_dropdownlist.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "Error while binding drop down list");
                    }

                }
            }

            protected void maintenance_job_dropdownlist_DataBinding()
            {
                DataTable maintenance_job_info = new DataTable();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [golivechecklist_maintenanceJobInfo] FROM [dbo].[BuildScreen_Dropdown] WHERE [golivechecklist_maintenanceJobInfo] IS NOT NULL;", con);
                        adapter.Fill(maintenance_job_info);

                        maintenance_job_dropdownlist.DataSource = maintenance_job_info;
                        maintenance_job_dropdownlist.DataTextField = "golivechecklist_maintenanceJobInfo";
                        maintenance_job_dropdownlist.DataValueField = "golivechecklist_maintenanceJobInfo";
                        maintenance_job_dropdownlist.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "Error while binding drop down list");
                    }

                }
            }

            protected void monitoring_tools_dropdownlist_DataBinding()
            {
                DataTable monitoring_tools_info = new DataTable();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [golivechecklist_monitoringtoolsInfo] FROM [dbo].[BuildScreen_Dropdown] WHERE [golivechecklist_monitoringtoolsInfo] IS NOT NULL;", con);
                        adapter.Fill(monitoring_tools_info);

                        monitoring_tools_dropdownlist.DataSource = monitoring_tools_info;
                        monitoring_tools_dropdownlist.DataTextField = "golivechecklist_monitoringtoolsInfo";
                        monitoring_tools_dropdownlist.DataValueField = "golivechecklist_monitoringtoolsInfo";
                        monitoring_tools_dropdownlist.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "Error while binding drop down list");
                    }

                }
            }

            protected void highavailability_info_dropdownlist_DataBinding()
            {
                DataTable highavailability_info_dropdownlist_info = new DataTable();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [golivechecklist_highavailabilityInfo] FROM [dbo].[BuildScreen_Dropdown] WHERE [golivechecklist_highavailabilityInfo] IS NOT NULL;", con);
                        adapter.Fill(highavailability_info_dropdownlist_info);

                        highavailability_info_dropdownlist.DataSource = highavailability_info_dropdownlist_info;
                        highavailability_info_dropdownlist.DataTextField = "golivechecklist_highavailabilityInfo";
                        highavailability_info_dropdownlist.DataValueField = "golivechecklist_highavailabilityInfo";
                        highavailability_info_dropdownlist.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "Error while binding drop down list");
                    }

                }
            }

            protected void dba_domain_dropdownlist_DataBinding()
            {
                DataTable dba_domain_info = new DataTable();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [golivechecklist_dbadomainupdate] FROM [dbo].[BuildScreen_Dropdown] WHERE [golivechecklist_dbadomainupdate] IS NOT NULL;", con);
                        adapter.Fill(dba_domain_info);

                        dba_domain_dropdownlist.DataSource = dba_domain_info;
                        dba_domain_dropdownlist.DataTextField = "golivechecklist_dbadomainupdate";
                        dba_domain_dropdownlist.DataValueField = "golivechecklist_dbadomainupdate";
                        dba_domain_dropdownlist.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "Error while binding drop down list");
                    }

                }
            }

            protected void ssis_info_dropdownlist_DataBinding()
            {
                DataTable ssis_info_dropdownlist_info = new DataTable();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [golivechecklist_ssisInfo] FROM [dbo].[BuildScreen_Dropdown] WHERE [golivechecklist_ssisInfo] IS NOT NULL;", con);
                        adapter.Fill(ssis_info_dropdownlist_info);

                        ssis_info_dropdownlist.DataSource = ssis_info_dropdownlist_info;
                        ssis_info_dropdownlist.DataTextField = "golivechecklist_ssisInfo";
                        ssis_info_dropdownlist.DataValueField = "golivechecklist_ssisInfo";
                        ssis_info_dropdownlist.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "Error while binding drop down list");
                    }

                }
            }

            protected void memory_settings_dropdownlist_DataBinding()
            {
                DataTable golivechecklist_memorySettings_info = new DataTable();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [golivechecklist_memorySettings] FROM [dbo].[BuildScreen_Dropdown] WHERE [golivechecklist_memorySettings] IS NOT NULL;", con);
                        adapter.Fill(golivechecklist_memorySettings_info);

                        memory_settings_dropdownlist.DataSource = golivechecklist_memorySettings_info;
                        memory_settings_dropdownlist.DataTextField = "golivechecklist_memorySettings";
                        memory_settings_dropdownlist.DataValueField = "golivechecklist_memorySettings";
                        memory_settings_dropdownlist.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Logging.LogException(ex, "Error while binding drop down list");
                    }

                }
            }

            protected void submit_Click(object sender, EventArgs e)
            {
                string serverName = lblhead_servername.Text;

                string defaultDB_info = chk_defaultdb.Checked ? "true" : "false";
                string serverRoles_info = chk_serverroles.Checked ? "true" : "false";
                string usermappings_info = chk_usermappings.Checked ? "true" : "false";
                string passwordsave_info = chk_passwordsave.Checked ? "true" : "false";

                string buildResource = Resource_name_dropdownlist.SelectedItem.Text;

                string linked_servers = linked_servers_dropdownlist.SelectedItem.Text;
                string linked_servers_notes = Request.Form["bld_linked_servers_notes"];

                string odbc_info = odbc_dropdownlist.SelectedItem.Text;
                string odbc_notes = Request.Form["bld_odbc_notes"];

                string client_info = client_info_dropdownlist.SelectedItem.Text;
                string client_info_notes = Request.Form["bld_client_info_notes"];

                string compatability_mode = compatability_mode_dropdownlist.SelectedItem.Text;
                string compatability_mode_notes = Request.Form["bld_compatability_mode_notes"];

                string database_mode_follow = database_mode_dropdownlist.SelectedItem.Text;
                string database_mode_notes = Request.Form["bld_database_mode_notes"];

                string backup_info = backup_info_dropdownlist.SelectedItem.Text;
                string backup_info_notes = Request.Form["bld_backup_info_notes"];

                string maintenance_job = maintenance_job_dropdownlist.SelectedItem.Text;
                string maintenance_job_notes = Request.Form["bld_maintenance_job_notes"];

                string monitoring_tools = monitoring_tools_dropdownlist.SelectedItem.Text;
                string monitoring_tools_notes = Request.Form["bld_monitoring_tools_notes"];

                string highavailability_info = highavailability_info_dropdownlist.SelectedItem.Text;
                string highavailability_info_notes = Request.Form["bld_highavailability_info_notes"];

                string dba_domain_info = dba_domain_dropdownlist.SelectedItem.Text;
                string dba_domain_notes = Request.Form["bld_dba_domain_notes"];

                string ssis_info = ssis_info_dropdownlist.SelectedItem.Text;
                string ssis_info_notes = Request.Form["bld_ssis_info_notes"];

                string memory_settings_info = memory_settings_dropdownlist.SelectedItem.Text;
                string memory_settings_notes = Request.Form["bld_memory_settings_notes"];

                string overallbuild_notes = Request.Form["bld_overall_notes"];

                string connString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(connString);
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO [GoLivecheckListFORM] ([ServerName],[Resourcename],[objectExecutionPermissions_defaultDB],[objectExecutionPermissions_serverRoles],[objectExecutionPermissions_userMappings],[objectExecutionPermissions_PasswordSave],[LinkedServers],[LinkedServers_notes],[ODBC],[ODBC_notes],[OracleClient_Info],[OracleClient_Info_notes],[CompatabilityMode],[CompatabilityMode_notes],[DatabaseMode],[DatabaseMode_notes],[BackupInfo],[BackupInfo_notes],[MaintenanceJobInfo],[MaintenanceJobInfo_notes],[MonitoringToolInfo],[MonitoringToolInfo_notes],[HighAvailabilityInfo],[HighAvailabilityInfo_notes],[DbaDomainUpdate],[DbaDomainUpdate_notes],[SSISInfo],[SSISInfo_notes],[MemorySettings],[MemorySettings_notes],[OverallBuildnotes]) Values (@serevrname,@buildresource,@defaultdb,@serverRoles,@usermappings,@passwordsave,@linkedservers,@linkedserversnotes,@odbc,@odbcnotes,@client,@clientnotes,@compatability,@compatabilitynotes,@databasemode,@databasemodenotes,@backup,@backupnotes,@maintenancejob,@maintenancejobnotes,@monitoring,@monitoringnotes,@highavailability,@highavailabilitynotes,@dbadomainupdate,@dbadomainupdatenotes,@ssisinfo,@ssisinfonotes,@memorysettings,@memorysettingsnotes,@overallbuildnotes)";

                        SqlParameter[] param = new SqlParameter[34];

                        param[3] = new SqlParameter("@serevrname", SqlDbType.NVarChar, 50);
                        param[4] = new SqlParameter("@buildresource", SqlDbType.NVarChar, 50);                        
                        param[5] = new SqlParameter("@defaultdb", SqlDbType.NVarChar, 50);                        
                        param[6] = new SqlParameter("@serverRoles", SqlDbType.NVarChar, 50);                        
                        param[7] = new SqlParameter("@usermappings", SqlDbType.NVarChar, 50);                        
                        param[8] = new SqlParameter("@passwordsave", SqlDbType.NVarChar, 50);
                        param[9] = new SqlParameter("@linkedservers", SqlDbType.NVarChar, 50);
                        param[10] = new SqlParameter("@linkedserversnotes", SqlDbType.NVarChar, 255);
                        param[11] = new SqlParameter("@odbc", SqlDbType.NVarChar, 50);
                        param[12] = new SqlParameter("@odbcnotes", SqlDbType.NVarChar, 255);
                        param[13] = new SqlParameter("@client", SqlDbType.NVarChar, 50);
                        param[14] = new SqlParameter("@clientnotes", SqlDbType.NVarChar, 255);
                        param[15] = new SqlParameter("@compatability", SqlDbType.NVarChar, 50);
                        param[16] = new SqlParameter("@compatabilitynotes", SqlDbType.NVarChar, 255);
                        param[17] = new SqlParameter("@databasemode", SqlDbType.NVarChar, 50);
                        param[18] = new SqlParameter("@databasemodenotes", SqlDbType.NVarChar, 255);
                        param[19] = new SqlParameter("@backup", SqlDbType.NVarChar, 50);
                        param[20] = new SqlParameter("@backupnotes", SqlDbType.NVarChar, 255);
                        param[21] = new SqlParameter("@maintenancejob", SqlDbType.NVarChar, 50);
                        param[22] = new SqlParameter("@maintenancejobnotes", SqlDbType.NVarChar, 255);
                        param[23] = new SqlParameter("@monitoring", SqlDbType.NVarChar, 50);
                        param[24] = new SqlParameter("@monitoringnotes", SqlDbType.NVarChar, 255);
                        param[25] = new SqlParameter("@highavailability", SqlDbType.NVarChar, 50);
                        param[26] = new SqlParameter("@highavailabilitynotes", SqlDbType.NVarChar, 255);
                        param[27] = new SqlParameter("@dbadomainupdate", SqlDbType.NVarChar, 50);
                        param[28] = new SqlParameter("@dbadomainupdatenotes", SqlDbType.NVarChar, 255);
                        param[29] = new SqlParameter("@ssisinfo", SqlDbType.NVarChar, 50);
                        param[30] = new SqlParameter("@ssisinfonotes", SqlDbType.NVarChar, 255);
                        param[31] = new SqlParameter("@memorysettings", SqlDbType.NVarChar, 50);
                        param[32] = new SqlParameter("@memorysettingsnotes", SqlDbType.NVarChar, 255);
                        param[33] = new SqlParameter("@overallbuildnotes", SqlDbType.NVarChar, 100);


                        param[3].Value = serverName;
                        param[4].Value = buildResource;
                        param[5].Value = defaultDB_info;
                        param[6].Value = serverRoles_info;
                        param[7].Value = usermappings_info;
                        param[8].Value = passwordsave_info;
                        param[9].Value = linked_servers;
                        param[10].Value = linked_servers_notes;
                        param[11].Value = odbc_info;
                        param[12].Value = odbc_notes;
                        param[13].Value = client_info;
                        param[14].Value = client_info_notes;
                        param[15].Value = compatability_mode;
                        param[16].Value = compatability_mode_notes;
                        param[17].Value = database_mode_follow;
                        param[18].Value = database_mode_notes;
                        param[19].Value = backup_info;
                        param[20].Value = backup_info_notes;
                        param[21].Value = maintenance_job;
                        param[22].Value = maintenance_job_notes;
                        param[23].Value = monitoring_tools;
                        param[24].Value = monitoring_tools_notes;
                        param[25].Value = highavailability_info;
                        param[26].Value = highavailability_info_notes;
                        param[27].Value = dba_domain_info;
                        param[28].Value = dba_domain_notes;
                        param[29].Value = ssis_info;
                        param[30].Value = ssis_info_notes;
                        param[31].Value = memory_settings_info;
                        param[32].Value = memory_settings_notes;                       
                        param[33].Value = overallbuild_notes;


                        for (int i = 3; i < param.Length; i++)
                        {
                            cmd.Parameters.Add(param[i]);
                        }


                        int rowsAffected = cmd.ExecuteNonQuery();
                        string url = ResolveUrl("~/GoLiveCheckListForm.aspx");
                        if (rowsAffected == 1)
                            Response.Write(String.Format("<script>alert('The records are inserted in to database successfully!');window.location='{0}';</script>", url));
                        else
                            Response.Write(String.Format("<script>alert('OOps there was an error while inserting in to database!');window.location='{0}';</script>", url));
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "Error while inserting into database - GoLivecheckListFORM");
                    string url = ResolveUrl("~/GoLiveCheckListForm.aspx");
                    Response.Write(String.Format("<script>alert('OOps there was an error while inserting in to database!');window.location='{0}';</script>", url));
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
    }
}