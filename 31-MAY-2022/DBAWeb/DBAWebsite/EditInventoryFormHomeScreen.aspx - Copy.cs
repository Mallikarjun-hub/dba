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
    public partial class EditInventoryFormHomeScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Server_dropdownlist_DataBinding();
        }

        protected void Server_dropdownlist_DataBinding()
        {
            DataTable server_name = new DataTable();
            SqlDataReader reader;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("usp_WebFormSelect", conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "decomissionform";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    server_name.Load(reader);
                    inventory_homescreen_Server_dropdownlist.DataSource = server_name;
                    inventory_homescreen_Server_dropdownlist.DataTextField = "Servername";
                    inventory_homescreen_Server_dropdownlist.DataValueField = "Servername";
                    inventory_homescreen_Server_dropdownlist.DataBind();
                    Logging.LogInfo("Successful binding on: QA home screen Dropdown", true);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "Error while executing the SP: usp_WebFormSelect");
                }
            }
        }

        protected void myBtn_Click(object sender, EventArgs e)
        {
            Application["Name"] = inventory_homescreen_Server_dropdownlist.Text;
            Response.Redirect("EditInventoryForm.aspx");
        }
    }
}