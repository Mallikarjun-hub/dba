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
    public partial class GoLiveCheckListHomeScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Server_dropdownlist_DataBinding();
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
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 10 [Servername] FROM [dbo].[AInventoryInfo] ORDER BY [SQLInstallDate] DESC", con);
                    adapter.Fill(server_name);

                    goLive_homescreen_Server_dropdownlist.DataSource = server_name;
                    goLive_homescreen_Server_dropdownlist.DataTextField = "Servername";
                    goLive_homescreen_Server_dropdownlist.DataValueField = "Servername";
                    goLive_homescreen_Server_dropdownlist.DataBind();
                    Logging.LogInfo("Successful binding on: Server Dropdown", true);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "Error in data bind");
                }

            }
        }

        protected void myBtn_Click(object sender, EventArgs e)
        {
            Application["Name"] = goLive_homescreen_Server_dropdownlist.Text;
            Response.Redirect("GoLiveCheckListForm.aspx");
        }


    }
}