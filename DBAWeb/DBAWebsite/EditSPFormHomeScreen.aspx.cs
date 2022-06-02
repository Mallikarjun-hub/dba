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
    public partial class EditSPFormHomeScreen : System.Web.UI.Page
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
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT [Servername] FROM [dbo].[AInventoryInfo] ORDER BY [SQLInstallDate] DESC", con);
                    adapter.Fill(server_name);

                    SP_homescreen_Server_dropdownlist.DataSource = server_name;
                    SP_homescreen_Server_dropdownlist.DataTextField = "Servername";
                    SP_homescreen_Server_dropdownlist.DataValueField = "Servername";
                    SP_homescreen_Server_dropdownlist.DataBind();
                }
                catch (Exception ex)
                {

                }

            }
        }


        protected void myBtn_Click(object sender, EventArgs e)
        {
            Application["SP_Server_Name"] = SP_homescreen_Server_dropdownlist.Text;
            Response.Redirect("EditSPForm.aspx");
        }


    }
}