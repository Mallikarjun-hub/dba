using DBAWebsite.APP;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBAWebsite
{
    public partial class BuildQAComparisonReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Application["BuildQAComparison_Server_Name"] != null)
                    lblhead_servername.Text = Application["BuildQAComparison_Server_Name"].ToString();

                buildQAComparisonReport_build_lables_DataBinding();
                buildQAComparisonReport_qa_lables_DataBinding();   
            }
        }

        protected void btn_send_Click(object sender, EventArgs e)
        {
            //StreamReader reader = new StreamReader(Server.MapPath("~/BuildQAComparisonReport.aspx"));
            //string readFile = reader.ReadToEnd();            
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();           
            mail.To.Add(ConfigurationManager.AppSettings["smtpUser"]);
            mail.CC.Add(ConfigurationManager.AppSettings["smtpCCUser"]);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["smtpSender"], "Email head", System.Text.Encoding.UTF8);
            mail.Subject = "Build/QA Comparison Report for Server: " + lblhead_servername.Text;            
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = lbl_compare_results.Text.Contains("differences") ? "Build/QA Comparison Report Failed" : "Build/QA Comparison Report Succeeded";            
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["smtpUser"], ConfigurationManager.AppSettings["smtpPass"]);
            client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
            client.Host = ConfigurationManager.AppSettings["smtpServer"];
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            string url = ResolveUrl("~/BuildQAComparisonReport.aspx");
            try
            {
                client.Send(mail);
                Response.Write(String.Format("<script>alert('Successfully Sent...!');window.location='{0}';</script>", url));
                Logging.LogInfo("Successfully sent mail");
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "Error while Sending the mail");
                Response.Write(String.Format("<script>alert('Sending Failed...!');window.location='{0}';</script>", url));
            }
        }        


        protected void btn_compare_Click(object sender, EventArgs e)
        {
            string temp = null;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("USP_CompareCheckLists", conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@servername", SqlDbType.VarChar).Value = lblhead_servername.Text;

                    conn.Open();
                    temp = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "Error while executing the SP: USP_CompareCheckLists");
                }
            }

            if (temp.Equals("GOOD"))
            {
                lbl_compare_results.Text = "Comparison looks good. Kindly submit the report";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                using (SqlCommand cmd = new SqlCommand("usp_InsertintoInventoryTracking", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@servername", SqlDbType.VarChar).Value = lblhead_servername.Text;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string url = ResolveUrl("~/BuildQAComparisonReport.aspx");
                        Response.Write(String.Format("<script>alert('There is an error while inserting data into Inventory Tracking...!');window.location='{0}';</script>", url));
                        Logging.LogException(ex, "Error while executing the SP: usp_InsertintoInventoryTracking");
                    }
                }
            }
            else
            {
                lbl_compare_results.Text = "Oops there are some differences in values. Kindly look into it";
            }
        }


        protected void buildQAComparisonReport_build_lables_DataBinding()
        {
            DataTable buildqacomparison_Info = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {

                try
                {
                    SqlCommand sqlCmd = new SqlCommand("select * from [dbo].[BUILDFORM] where servername = @servername", con);
                    sqlCmd.Parameters.AddWithValue("@servername", lblhead_servername.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                    adapter.Fill(buildqacomparison_Info);

                    if (buildqacomparison_Info.Rows.Count > 0)
                    {
                        //Server_Memory_autovalue.Text = buildqacomparison_Info.Rows[0]["BuildDate"].ToString();
                        //SQL_Memory_autovalue.Text = buildqacomparison_Info.Rows[0]["ServerName"].ToString();
                        ldlbuild_ResourceName.Text = buildqacomparison_Info.Rows[0]["BuildResource"].ToString();
                        ldlbuild_dbadb.Text = buildqacomparison_Info.Rows[0]["dbadbCreated"].ToString();
                        ldlbuild_memoryCapped.Text = buildqacomparison_Info.Rows[0]["MemoryCapped"].ToString();
                        ldlbuild_initialBackup.Text = buildqacomparison_Info.Rows[0]["InitialBackup"].ToString();
                        ldlbuild_backupSchedule.Text = buildqacomparison_Info.Rows[0]["BackupScheduled"].ToString();
                        ldlbuild_goliveDate.Text = buildqacomparison_Info.Rows[0]["GOLiveDate"].ToString();
                        ldlbuild_drivelayout.Text = buildqacomparison_Info.Rows[0]["FollowDriveLayout"].ToString();
                        ldlbuild_sqlVersion.Text = buildqacomparison_Info.Rows[0]["SQLVersion"].ToString();
                        ldlbuild_monitorTool.Text = buildqacomparison_Info.Rows[0]["MonitoringTool"].ToString();
                        ldlbuild_highAvailability.Text = buildqacomparison_Info.Rows[0]["HighAvailability"].ToString();
                        ldlbuild_processorscores.Text = buildqacomparison_Info.Rows[0]["No.ofProcessorsandcores"].ToString();
                        ldlbuild_mailsetup.Text = buildqacomparison_Info.Rows[0]["MailSetup"].ToString();
                        ldlbuild_memory.Text = buildqacomparison_Info.Rows[0]["MemoryCorrect"].ToString();
                        ldlbuild_admin.Text = buildqacomparison_Info.Rows[0]["ServerAdministrators"].ToString();
                        ldlbuild_services.Text = buildqacomparison_Info.Rows[0]["ServicesDisabled"].ToString();
                        ldlbuild_maintenance.Text = buildqacomparison_Info.Rows[0]["MaintenanceSet"].ToString();
                        ldlbuild_lockpages.Text = buildqacomparison_Info.Rows[0]["PagesLocked"].ToString();
                        ldlbuild_version.Text = buildqacomparison_Info.Rows[0]["VersionCorrect"].ToString();
                        ldlbuild_maxdop.Text = buildqacomparison_Info.Rows[0]["MaxdopSet"].ToString();
                        ldlbuild_countset.Text = buildqacomparison_Info.Rows[0]["CountSet"].ToString();
                        ldlbuild_traceflag.Text = buildqacomparison_Info.Rows[0]["TraceFlag"].ToString();
                        ldlbuild_verified.Text = buildqacomparison_Info.Rows[0]["JobsVerified"].ToString();
                        ldlbuild_sucessful.Text = buildqacomparison_Info.Rows[0]["JobsSucessful"].ToString();
                        ldlbuild_agentalerts.Text = buildqacomparison_Info.Rows[0]["AgentAlerts"].ToString();
                        ldlbuild_securitysetup.Text = buildqacomparison_Info.Rows[0]["SecuritySetup"].ToString();
                        ldlbuild_accountscorrect.Text = buildqacomparison_Info.Rows[0]["AccountsCorrect"].ToString();
                        ldlbuild_accountsstored.Text = buildqacomparison_Info.Rows[0]["AccountsStoredS"].ToString();

                    }

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "Error while Fetching buildForm data");
                }

            }
        }


        protected void buildQAComparisonReport_qa_lables_DataBinding()
        {
            DataTable buildqacomparison_Info = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {

                try
                {
                    SqlCommand sqlCmd = new SqlCommand("select * from [dbo].[QAFORM] where servername = @servername", con);
                    sqlCmd.Parameters.AddWithValue("@servername", lblhead_servername.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);

                    adapter.Fill(buildqacomparison_Info);

                    if (buildqacomparison_Info.Rows.Count > 0)
                    {
                        //Server_Memory_autovalue.Text = buildqacomparison_Info.Rows[0]["BuildDate"].ToString();
                        //SQL_Memory_autovalue.Text = buildqacomparison_Info.Rows[0]["ServerName"].ToString();
                        ldlqa_ResourceName.Text = buildqacomparison_Info.Rows[0]["QAResource"].ToString();
                        ldlqa_dbadb.Text = buildqacomparison_Info.Rows[0]["dbadbCreated"].ToString();
                        ldlqa_memoryCapped.Text = buildqacomparison_Info.Rows[0]["MemoryCapped"].ToString();
                        ldlqa_initialBackup.Text = buildqacomparison_Info.Rows[0]["InitialBackup"].ToString();
                        ldlqa_backupSchedule.Text = buildqacomparison_Info.Rows[0]["BackupScheduled"].ToString();
                        ldlqa_goliveDate.Text = buildqacomparison_Info.Rows[0]["GOLiveDate"].ToString();
                        ldlqa_drivelayout.Text = buildqacomparison_Info.Rows[0]["FollowDriveLayout"].ToString();
                        ldlqa_sqlVersion.Text = buildqacomparison_Info.Rows[0]["SQLVersion"].ToString();
                        ldlqa_monitorTool.Text = buildqacomparison_Info.Rows[0]["MonitoringTool"].ToString();
                        ldlqa_highAvailability.Text = buildqacomparison_Info.Rows[0]["HighAvailability"].ToString();
                        ldlqa_processorscores.Text = buildqacomparison_Info.Rows[0]["No.ofProcessorsandcores"].ToString();
                        ldlqa_mailsetup.Text = buildqacomparison_Info.Rows[0]["MailSetup"].ToString();
                        ldlqa_memory.Text = buildqacomparison_Info.Rows[0]["MemoryCorrect"].ToString();
                        ldlqa_admin.Text = buildqacomparison_Info.Rows[0]["ServerAdministrators"].ToString();
                        ldlqa_services.Text = buildqacomparison_Info.Rows[0]["ServicesDisabled"].ToString();
                        ldlqa_maintenance.Text = buildqacomparison_Info.Rows[0]["MaintenanceSet"].ToString();
                        ldlqa_lockpages.Text = buildqacomparison_Info.Rows[0]["PagesLocked"].ToString();
                        ldlqa_version.Text = buildqacomparison_Info.Rows[0]["VersionCorrect"].ToString();
                        ldlqa_maxdop.Text = buildqacomparison_Info.Rows[0]["MaxdopSet"].ToString();
                        ldlqa_countset.Text = buildqacomparison_Info.Rows[0]["CountSet"].ToString();
                        ldlqa_traceflag.Text = buildqacomparison_Info.Rows[0]["TraceFlag"].ToString();
                        ldlqa_verified.Text = buildqacomparison_Info.Rows[0]["JobsVerified"].ToString();
                        ldlqa_sucessful.Text = buildqacomparison_Info.Rows[0]["JobsSucessful"].ToString();
                        ldlqa_agentalerts.Text = buildqacomparison_Info.Rows[0]["AgentAlerts"].ToString();
                        ldlqa_securitysetup.Text = buildqacomparison_Info.Rows[0]["SecuritySetup"].ToString();
                        ldlqa_accountscorrect.Text = buildqacomparison_Info.Rows[0]["AccountsCorrect"].ToString();
                        ldlqa_accountsstored.Text = buildqacomparison_Info.Rows[0]["AccountsStored"].ToString();


                    }

                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "Error while Fetching QAForm data");
                }

            }
        }
    }
}