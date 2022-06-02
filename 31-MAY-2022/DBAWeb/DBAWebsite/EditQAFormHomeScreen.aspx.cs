using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBAWebsite.APP;

namespace DBAWebsite
{
    public partial class EditQAFormHomeScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Server_dropdownlist_DataBinding();
            Server_fulldropdownlist_DataBinding();
        }

        protected void Server_dropdownlist_DataBinding()
        {
            //  SELECT DISTINCT [Server\Instance] FROM [DBA_TEST].[dbo].[SQLServersList] WHERE [InsertDate] > getdate()-30;

            DataTable server_name = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {

                try
                {
                    //SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT [Servername] FROM [DBA_T//EST].[dbo].[SQLServersList] WHERE [InsertDate] > getdate()-30", con);
                    //SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 10 [Servername] FROM [dbo].[AInventoryInfo] ORDER BY [InsertDate] DESC", con);
                    SqlDataAdapter adapter = new SqlDataAdapter("EXECUTE [dbo].[usp_WebFormSelect] @query = 'editform'", con);
                    adapter.Fill(server_name);

                    qa_homescreen_Server_dropdownlist.DataSource = server_name;
                    qa_homescreen_Server_dropdownlist.DataTextField = "Servername";
                    qa_homescreen_Server_dropdownlist.DataValueField = "Servername";
                    qa_homescreen_Server_dropdownlist.DataBind();
                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void Server_fulldropdownlist_DataBinding()
        {
            DataTable server_name2 = new DataTable();
            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_WebFormSelect", conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "fullserverlist";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    server_name2.Load(reader);
                    qa_homescreen_Server_fulldropdownlist.DataSource = server_name2;
                    qa_homescreen_Server_fulldropdownlist.DataTextField = "Servername";
                    qa_homescreen_Server_fulldropdownlist.DataValueField = "Servername";
                    qa_homescreen_Server_fulldropdownlist.DataBind();
                    Logging.LogInfo("Successful binding on: Inventory Dropdown", true);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "Error while executing the SP: usp_WebFormSelect");
                }
            }
        }
        protected void myBtn_Click(object sender, EventArgs e)
        {
            Application["qa_Server_Name"] = qa_homescreen_Server_fulldropdownlist.Text;
            Response.Redirect("EditQAForm.aspx");
        }

        protected void myBtn_Click2(object sender, EventArgs e)
        {
            Application["qa_Server_Name"] = qa_homescreen_Server_dropdownlist.Text;
            Response.Redirect("EditQAForm.aspx");
        }

    }
}