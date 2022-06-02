using DBAWebsite.APP;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBAWebsite
{
    public partial class UpgradeServerForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Application["UpgradeOldServerName"] != null && Application["UpgradeNewServerName"] != null)
                {
                    lblhead_servername.Text = Application["UpgradeOldServerName"].ToString();
                    upgrade_Server_autovalue.Text = Application["UpgradeOldServerName"].ToString();
                    upgrade_Server_new_autovalue.Text = Application["UpgradeNewServerName"].ToString();
                }

                upgradeForm_oldSever_lables_DataBinding();
                upgradeForm_newServer_lables_DataBinding();              

                Server_name_dropdownlist_DataBinding();
                server_memory_dropdownlist_DataBinding();
                sql_memory_dropdownlist_DataBinding();
                noofprocessors_dropdownlist_DataBinding();
                noofcores_dropdownlist_DataBinding();
                sqlversion_dropdownlist_DataBinding();
                compatability_DropDownList_DataBinding();
            }
            else
            {
                string datepickervalue = Request.Form["SQLupgradeDate"];
                inpHide_upgrade.Value = datepickervalue;
            }
        }

        protected void upgradeForm_oldSever_lables_DataBinding()
        {
            DataTable upgradeFormlable_Info = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                try
                {
                    SqlCommand sqlCmd = new SqlCommand("select * from [dbo].[InventoryTracking] where servername = @servername", con);
                    sqlCmd.Parameters.AddWithValue("@servername", upgrade_Server_autovalue.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                    adapter.Fill(upgradeFormlable_Info);

                    if (upgradeFormlable_Info.Rows.Count > 0)
                    {
                        upgrade_processors_autovalue.Text = upgradeFormlable_Info.Rows[0]["NumberOfProcessors"].ToString();
                        upgrade_cores_autovalue.Text = upgradeFormlable_Info.Rows[0]["NumberOfLogicalProcessors"].ToString();
                        upgrade_version_autovalue.Text = upgradeFormlable_Info.Rows[0]["DBVersionShort"].ToString();                       
                    }

                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void upgradeForm_newServer_lables_DataBinding()
        {
            DataTable upgradeFormlable_Info = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {

                try
                {
                    SqlCommand sqlCmd = new SqlCommand("select * from [dbo].[AInventoryInfo] where servername = @servername", con);
                    sqlCmd.Parameters.AddWithValue("@servername", upgrade_Server_new_autovalue.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                    adapter.Fill(upgradeFormlable_Info);

                    if (upgradeFormlable_Info.Rows.Count > 0)
                    {
                        upgrade_processors_new_autovalue.Text = upgradeFormlable_Info.Rows[0]["NumberOfProcessors"].ToString();
                        upgrade_cores_new_autovalue.Text = upgradeFormlable_Info.Rows[0]["NumberOfLogicalProcessors"].ToString();
                        upgrade_servermemory_autovalue.Text = upgradeFormlable_Info.Rows[0]["TotalPhysicalMemoryGB"].ToString();
                        upgrade_sqlmemory_autovalue.Text = upgradeFormlable_Info.Rows[0]["MAXServerMemoryMB"].ToString();
                        upgrade_version_new_autovalue.Text = upgradeFormlable_Info.Rows[0]["SQLVersionShort"].ToString();                        
                    }

                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void Server_name_dropdownlist_DataBinding()
        {
            DataTable upgrade_serverName_info = new DataTable();

            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_WebFormSelect", conn))
            {

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "upgradeservername";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    upgrade_serverName_info.Load(reader);

                    Server_name_dropdownlist.DataSource = upgrade_serverName_info;
                    Server_name_dropdownlist.DataTextField = "Upgrade_Servername";
                    Server_name_dropdownlist.DataValueField = "Upgrade_Servername";
                    Server_name_dropdownlist.DataBind();
                }
                catch (Exception ex)
                {

                }

            }   
        }

        protected void server_memory_dropdownlist_DataBinding()
        {
            DataTable upgrade_serverMemory_info = new DataTable();

            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_WebFormSelect", conn))
            {

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "upgradeservermemory";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    upgrade_serverMemory_info.Load(reader);

                    server_memory_dropdownlist.DataSource = upgrade_serverMemory_info;
                    server_memory_dropdownlist.DataTextField = "Upgrade_ServerMemory";
                    server_memory_dropdownlist.DataValueField = "Upgrade_ServerMemory";
                    server_memory_dropdownlist.DataBind();
                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void sql_memory_dropdownlist_DataBinding()
        {
            DataTable upgrade_sqlMemory_info = new DataTable();

            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_WebFormSelect", conn))
            {

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "upgradesqlmemory";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    upgrade_sqlMemory_info.Load(reader);

                    sql_memory_dropdownlist.DataSource = upgrade_sqlMemory_info;
                    sql_memory_dropdownlist.DataTextField = "Upgrade_SqlMemory";
                    sql_memory_dropdownlist.DataValueField = "Upgrade_SqlMemory";
                    sql_memory_dropdownlist.DataBind();
                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void noofprocessors_dropdownlist_DataBinding()
        {
            DataTable upgrade_noofprocessors_info = new DataTable();

            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_WebFormSelect", conn))
            {

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "upgradeNoofprocessors";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    upgrade_noofprocessors_info.Load(reader);

                    noofprocessors_dropdownlist.DataSource = upgrade_noofprocessors_info;
                    noofprocessors_dropdownlist.DataTextField = "Upgrade_NoofProcessors";
                    noofprocessors_dropdownlist.DataValueField = "Upgrade_NoofProcessors";
                    noofprocessors_dropdownlist.DataBind();
                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void noofcores_dropdownlist_DataBinding()
        {
            DataTable upgrade_noofCores_info = new DataTable();

            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_WebFormSelect", conn))
            {

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "upgradeNoofcores";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    upgrade_noofCores_info.Load(reader);

                    noofcores_dropdownlist.DataSource = upgrade_noofCores_info;
                    noofcores_dropdownlist.DataTextField = "Upgrade_NoofCores";
                    noofcores_dropdownlist.DataValueField = "Upgrade_NoofCores";
                    noofcores_dropdownlist.DataBind();
                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void sqlversion_dropdownlist_DataBinding()
        {
            DataTable upgrade_sqlversion_info = new DataTable();

            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_WebFormSelect", conn))
            {

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "upgradesqlversion";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    upgrade_sqlversion_info.Load(reader);

                    sqlversion_dropdownlist.DataSource = upgrade_sqlversion_info;
                    sqlversion_dropdownlist.DataTextField = "Upgrade_sqlVersion";
                    sqlversion_dropdownlist.DataValueField = "Upgrade_sqlVersion";
                    sqlversion_dropdownlist.DataBind();
                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void compatability_DropDownList_DataBinding()
        {
            DataTable upgrade_compatability_info = new DataTable();

            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_WebFormSelect", conn))
            {

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "upgradecompatability";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    upgrade_compatability_info.Load(reader);

                    compatability_DropDownList.DataSource = upgrade_compatability_info;
                    compatability_DropDownList.DataTextField = "Upgrade_compatability";
                    compatability_DropDownList.DataValueField = "Upgrade_compatability";
                    compatability_DropDownList.DataBind();
                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void myBtn_Click(object sender, EventArgs e)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_UpdateInventoryTracking", conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@oldservername", SqlDbType.VarChar).Value = upgrade_Server_autovalue.Text;
                    cmd.Parameters.Add("@newservername", SqlDbType.VarChar).Value = upgrade_Server_new_autovalue.Text;
                    cmd.Parameters.Add("@upgradedate", SqlDbType.Date).Value = inpHide_upgrade.Value;

                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "Error while executing the SP: USP_CompareCheckLists");
                }
            }

            sendMainTask(result);
            inserttoDataBase();
        }


        protected void sendMainTask(int result)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(ConfigurationManager.AppSettings["smtpUser"]);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["smtpSender"], "Email head", System.Text.Encoding.UTF8);
            mail.Subject = "Upgrading Server: " + upgrade_Server_autovalue.Text + " to " + upgrade_Server_new_autovalue.Text;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = (result == -1) ? "Upgrading Server Succeeded" : "Upgrading Server Failed";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["smtpUser"], ConfigurationManager.AppSettings["smtpPass"]);
            client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
            client.Host = ConfigurationManager.AppSettings["smtpServer"];
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            string url = ResolveUrl("~/UpgradeServerForm.aspx");
            try
            {
                client.Send(mail);
                Response.Write(String.Format("<script>alert('Mail Successfully Sent...!');window.location='{0}';</script>", url));
                Logging.LogInfo("Successfully sent mail");
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "Error while Sending the mail");
                Response.Write(String.Format("<script>alert('Sending Mail Failed...!');window.location='{0}';</script>", url));
            }
        }

        protected void inserttoDataBase()
        {
            string oldserverName = upgrade_Server_autovalue.Text;
            string olddbversion = upgrade_version_autovalue.Text;
            string oldnoofprocessors = upgrade_processors_autovalue.Text;
            string oldnoofcores = upgrade_cores_autovalue.Text;
            string newserverName = upgrade_Server_new_autovalue.Text;
            string newdbversion = upgrade_version_new_autovalue.Text;
            string newnoofprocessors = upgrade_processors_new_autovalue.Text;
            string newnoofcores = upgrade_cores_new_autovalue.Text;
            string newservermemory = upgrade_servermemory_autovalue.Text;
            string newsqlmemory = upgrade_sqlmemory_autovalue.Text;


            string server_confirmation = Server_name_dropdownlist.SelectedItem.Text;
            string server_notes = Request.Form["servername_notes"];

            string upgrade_date = inpHide_upgrade.Value;
            string upgrade_date_notes = Request.Form["upgrade_date_notes"];

            string servermemory_confirmation = server_memory_dropdownlist.SelectedItem.Text;
            string servermemory_notes = Request.Form["upgrade_servermemory_notes"];

            string sqlmemory_confirmation = sql_memory_dropdownlist.SelectedItem.Text;
            string sqlmemory_notes = Request.Form["upgrade_sqlmemory_notes"];

            string noofprocessors_confirmation = noofprocessors_dropdownlist.SelectedItem.Text;
            string noofprocessors_notes = Request.Form["upgrade_noofprocessors_notes"];

            string noofcores_confirmation = noofcores_dropdownlist.SelectedItem.Text;
            string noofcores_notes = Request.Form["upgrade_noofcores_notes"];

            string sqlversion_confirmation = sqlversion_dropdownlist.SelectedItem.Text;
            string sqlversion_notes = Request.Form["upgrade_sqlversion_notes"];

            string compatability_confirmation = compatability_DropDownList.SelectedItem.Text;
            string compatability_notes = Request.Form["upgrade_compatability_notes"];

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
                    cmd.CommandText = "INSERT INTO UPGRADEFORM ([oldServerName],[olddbversion],[oldnoofprocessors],[oldnoofcores],[newServerName],[newdbversion],[newnoofprocessors],[newnoofcores],[newservermemory],[newsqlmemory],[Servername_confirmation],[Servername_Notes],[upgradedate],[upgradedate_Notes],[Servermemory_confirmation],[Servermemory_Notes],[Sqlmemory_confirmation],[Sqlmemory_Notes],[noofprocessors_confirmation],[noofprocessors_Notes],[noofcores_confirmation],[noofcores_Notes],[sqlversion_confirmation],[sqlversion_Notes],[compatability_confirmation],[compatability_Notes]) Values (@oldserevrname,@olddbversion,@oldnoofprocessors,@oldnoofcores,@newServerName,@newdbversion,@newnoofprocessors,@newnoofcores,@newservermemory,@newsqlmemory,@Servername_confirmation,@Servername_Notes,@upgradedate,@upgradedate_Notes,@Servermemory_confirmation,@Servermemory_Notes,@Sqlmemory_confirmation,@Sqlmemory_Notes,@noofprocessors_confirmation,@noofprocessors_Notes,@noofcores_confirmation,@noofcores_Notes,@sqlversion_confirmation,@sqlversion_Notes,@compatability_confirmation,@compatability_Notes)";

                    SqlParameter[] param = new SqlParameter[29];

                    param[3] = new SqlParameter("@oldserevrname", SqlDbType.NVarChar, 50);
                    param[4] = new SqlParameter("@olddbversion", SqlDbType.NVarChar, 50);
                    param[5] = new SqlParameter("@oldnoofprocessors", SqlDbType.NVarChar, 50);
                    param[6] = new SqlParameter("@oldnoofcores", SqlDbType.NVarChar, 50);
                    param[7] = new SqlParameter("@newServerName", SqlDbType.NVarChar, 50);
                    param[8] = new SqlParameter("@newdbversion", SqlDbType.NVarChar, 50);
                    param[9] = new SqlParameter("@newnoofprocessors", SqlDbType.NVarChar, 50);
                    param[10] = new SqlParameter("@newnoofcores", SqlDbType.NVarChar, 50);
                    param[11] = new SqlParameter("@newservermemory", SqlDbType.NVarChar, 50);
                    param[12] = new SqlParameter("@newsqlmemory", SqlDbType.NVarChar, 50);
                    param[13] = new SqlParameter("@Servername_confirmation", SqlDbType.NVarChar, 50);
                    param[14] = new SqlParameter("@Servername_Notes", SqlDbType.NVarChar, 100);
                    param[15] = new SqlParameter("@upgradedate", SqlDbType.Date);
                    param[16] = new SqlParameter("@upgradedate_Notes", SqlDbType.NVarChar, 100);
                    param[17] = new SqlParameter("@Servermemory_confirmation", SqlDbType.NVarChar, 50);
                    param[18] = new SqlParameter("@Servermemory_Notes", SqlDbType.NVarChar, 100);
                    param[19] = new SqlParameter("@Sqlmemory_confirmation", SqlDbType.NVarChar, 50);
                    param[20] = new SqlParameter("@Sqlmemory_Notes", SqlDbType.NVarChar, 100);
                    param[21] = new SqlParameter("@noofprocessors_confirmation", SqlDbType.NVarChar, 50);
                    param[22] = new SqlParameter("@noofprocessors_Notes", SqlDbType.NVarChar, 100);
                    param[23] = new SqlParameter("@noofcores_confirmation", SqlDbType.NVarChar, 50);
                    param[24] = new SqlParameter("@noofcores_Notes", SqlDbType.NVarChar, 100);
                    param[25] = new SqlParameter("@sqlversion_confirmation", SqlDbType.NVarChar, 50);
                    param[26] = new SqlParameter("@sqlversion_Notes", SqlDbType.NVarChar, 100);
                    param[27] = new SqlParameter("@compatability_confirmation", SqlDbType.NVarChar, 50);
                    param[28] = new SqlParameter("@compatability_Notes", SqlDbType.NVarChar, 100);


                    param[3].Value = oldserverName;
                    param[4].Value = olddbversion;
                    param[5].Value = oldnoofprocessors;
                    param[6].Value = oldnoofcores;
                    param[7].Value = newserverName;
                    param[8].Value = newdbversion;
                    param[9].Value = newnoofprocessors;
                    param[10].Value = newnoofcores;
                    param[11].Value = newservermemory;
                    param[12].Value = newsqlmemory;
                    param[13].Value = server_confirmation;
                    param[14].Value = server_notes;
                    param[15].Value = upgrade_date;
                    param[16].Value = upgrade_date_notes;
                    param[17].Value = servermemory_confirmation;
                    param[18].Value = servermemory_notes;
                    param[19].Value = sqlmemory_confirmation;
                    param[20].Value = sqlmemory_notes;
                    param[21].Value = noofprocessors_confirmation;
                    param[22].Value = noofprocessors_notes;
                    param[23].Value = noofcores_confirmation;
                    param[24].Value = noofcores_notes;
                    param[25].Value = sqlversion_confirmation;
                    param[26].Value = sqlversion_notes;
                    param[27].Value = compatability_confirmation;
                    param[28].Value = compatability_notes;                  


                    for (int i = 3; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }


                    int rowsAffected = cmd.ExecuteNonQuery();
                    string url = ResolveUrl("~/UpgradeServerForm.aspx");
                    if (rowsAffected == 1)
                        Response.Write(String.Format("<script>alert('The records are inserted in to database successfully!');window.location='{0}';</script>", url));
                    else
                        Response.Write(String.Format("<script>alert('OOps there was an error while inserting in to database!');window.location='{0}';</script>", url));
                }
            }
            catch (Exception ex)
            {
                string url = ResolveUrl("~/UpgradeServerForm.aspx");
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