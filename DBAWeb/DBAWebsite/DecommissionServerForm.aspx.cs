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
    public partial class DecommissionServerForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Application["DecommissionServerName"] != null)
                    lblhead_servername.Text = Application["DecommissionServerName"].ToString();

                decommissionForm_lables_DataBinding();
                decommission_noofProcessors_dropdownlist_DataBinding();
                decommission_noofCores_dropdownlist_DataBinding();
            }
            else
            {
                string stopdate_datepickervalue = Request.Form["SQLstopDate"];
                stopDate_Hide.Value = stopdate_datepickervalue;
                string uninstalldate_datepickervalue = Request.Form["SQLUninstallDate"];
                uninstallDate_Hide.Value = uninstalldate_datepickervalue;
            }
        }

        protected void decommission_noofProcessors_dropdownlist_DataBinding()
        {
            DataTable decommission_noofProcessors_info = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [Decommission_Noofprocessors] FROM [dbo].[BuildScreen_Dropdown] WHERE [Decommission_Noofprocessors] IS NOT NULL;", con);
                    adapter.Fill(decommission_noofProcessors_info);

                    noofProcessors_dropdownlist.DataSource = decommission_noofProcessors_info;
                    noofProcessors_dropdownlist.DataTextField = "Decommission_Noofprocessors";
                    noofProcessors_dropdownlist.DataValueField = "Decommission_Noofprocessors";
                    noofProcessors_dropdownlist.DataBind();
                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void decommission_noofCores_dropdownlist_DataBinding()
        {
            DataTable decommission_noofCores_info = new DataTable();

            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_WebFormSelect", conn))
            {

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "DecommissionNoofcores";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    decommission_noofCores_info.Load(reader);

                    noofcores_dropdownlist.DataSource = decommission_noofCores_info;
                    noofcores_dropdownlist.DataTextField = "Decommission_Noofcores";
                    noofcores_dropdownlist.DataValueField = "Decommission_Noofcores";
                    noofcores_dropdownlist.DataBind();
                }
                catch (Exception ex)
                {

                }

            }
        }        

        protected void decommissionForm_lables_DataBinding()
        {
            DataTable buildFormlable_Info = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {

                try
                {
                    SqlCommand sqlCmd = new SqlCommand("select * from [dbo].[AInventoryInfo] where servername = @servername", con);
                    sqlCmd.Parameters.AddWithValue("@servername", lblhead_servername.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                    adapter.Fill(buildFormlable_Info);

                    if (buildFormlable_Info.Rows.Count > 0)
                    {
                        lbldecommission_noofProcessors.Text = buildFormlable_Info.Rows[0]["NumberOfProcessors"].ToString();
                        lbldecommission_noofcores.Text = buildFormlable_Info.Rows[0]["NumberOfLogicalProcessors"].ToString();                       
                    }
                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void send_mail()
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(ConfigurationManager.AppSettings["smtpUser"]);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["smtpSender"], "Email head", System.Text.Encoding.UTF8);
            mail.Subject = "Decommissioned the Server: " + lblhead_servername.Text;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Decommissioned the server: " + lblhead_servername.Text + " - Succeeded";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["smtpUser"], ConfigurationManager.AppSettings["smtpPass"]);
            client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
            client.Host = ConfigurationManager.AppSettings["smtpServer"];
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            string url = ResolveUrl("~/DecommissionServerForm.aspx");
            try
            {
                client.Send(mail);
                Response.Write(String.Format("<script>alert('Mail Successfully Sent...!');window.location='{0}';</script>", url));
                Logging.LogInfo("Successfully sent mail");
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "Error while Sending the mail");
                Response.Write(String.Format("<script>alert('Mail Sending Failed...!');window.location='{0}';</script>", url));
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string serverName = lblhead_servername.Text;
            string noofProcessors = lbldecommission_noofProcessors.Text;
            string noofCores = lbldecommission_noofcores.Text;
            string noofProcessors_Confirmation = noofProcessors_dropdownlist.SelectedItem.Text;
            string noofCores_Confirmation = noofcores_dropdownlist.SelectedItem.Text;
            string sql_stopDate = stopDate_Hide.Value;
            string sql_uninstallDate = uninstallDate_Hide.Value;

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
                    cmd.CommandText = "INSERT INTO DecommissionForm ([ServerName],[NumberOfProcessors],[NumberOfProcessorsConfirmation],[NumberOfLogicalProcessors],[NumberOfLogicalProcessorsConfirmation],[SQLServerStopDate],[SQLServerUninstallDate]) Values (@serevrname,@noofProcessors,@noofProcessors_Confirmation,@noofCores,@noofCores_Confirmation,@sql_stopDate,@sql_uninstallDate)";

                    SqlParameter[] param = new SqlParameter[10];

                    param[3] = new SqlParameter("@serevrname", SqlDbType.NVarChar, 50);
                    param[4] = new SqlParameter("@noofProcessors", SqlDbType.NVarChar, 10);
                    param[5] = new SqlParameter("@noofProcessors_Confirmation", SqlDbType.NVarChar, 10);
                    param[6] = new SqlParameter("@noofCores", SqlDbType.NVarChar, 10);
                    param[7] = new SqlParameter("@noofCores_Confirmation", SqlDbType.NVarChar, 10);
                    param[8] = new SqlParameter("@sql_stopDate", SqlDbType.Date);
                    param[9] = new SqlParameter("@sql_uninstallDate", SqlDbType.Date);                    


                    param[3].Value = serverName;
                    param[4].Value = noofProcessors;
                    param[5].Value = noofProcessors_Confirmation;
                    param[6].Value = noofCores;
                    param[7].Value = noofCores_Confirmation;
                    param[8].Value = sql_stopDate;
                    param[9].Value = sql_uninstallDate;                    

                    for (int i = 3; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }


                    int rowsAffected = cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE InventoryTracking set [RecordUpdateDate] = @currentDate,[ServicesStopDate] = @sql_stopDate1,[UninstallDate] = @sql_uninstallDate1,[status] = @status WHERE [servername] = @serevrname1";

                    param = new SqlParameter[6];

                    param[1] = new SqlParameter("@currentDate", SqlDbType.DateTime);                    
                    param[2] = new SqlParameter("@sql_stopDate1", SqlDbType.DateTime);
                    param[3] = new SqlParameter("@sql_uninstallDate1", SqlDbType.DateTime);
                    param[4] = new SqlParameter("@status", SqlDbType.VarChar, 200);
                    param[5] = new SqlParameter("@serevrname1", SqlDbType.VarChar, 200);

                    param[1].Value = DateTime.Now.ToString();
                    param[2].Value = sql_stopDate;
                    param[3].Value = sql_uninstallDate;
                    param[4].Value = "Decommissioned";
                    param[5].Value = serverName;                                     

                    for (int i = 1; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }
                    int rowsUpdated = cmd.ExecuteNonQuery();

                    string url = ResolveUrl("~/DecommissionServerForm.aspx");
                    if (rowsAffected == 1 && rowsUpdated == 1)
                    {
                        send_mail();
                        Response.Write(String.Format("<script>alert('The records are inserted and updated in to database successfully!!! Mail has been sent');window.location='{0}';</script>", url));                        
                    }
                    else
                    {
                        if (rowsAffected == 1)
                            Response.Write(String.Format("<script>alert('OOps there was an error while Updating in to database!');window.location='{0}';</script>", url));
                        else
                            Response.Write(String.Format("<script>alert('OOps there was an error while Inserting in to database!');window.location='{0}';</script>", url));
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "Error while updating the database or sending mail");
                string url = ResolveUrl("~/DecommissionServerForm.aspx");
                Response.Write(String.Format("<script>alert('OOps there was an error while inserting/updating in to database!!!');window.location='{0}';</script>", url));
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