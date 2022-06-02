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
    public partial class CreateQAFormHomeScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Server_dropdownlist_DataBinding();
            Server_fulldropdownlist_DataBinding();
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
                    cmd.Parameters.Add("@query", SqlDbType.VarChar).Value = "newform";
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    server_name.Load(reader);
                    qa_homescreen_Server_dropdownlist.DataSource = server_name;
                    qa_homescreen_Server_dropdownlist.DataTextField = "Servername";
                    qa_homescreen_Server_dropdownlist.DataValueField = "Servername";
                    qa_homescreen_Server_dropdownlist.DataBind();
                    Logging.LogInfo("Successful binding on: QA home screen Dropdown", true);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "Error while executing the SP: usp_WebFormSelect");
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
            Response.Redirect("CreateQAForm.aspx");
        }
        protected void myBtn_Click2(object sender, EventArgs e)
        {
            Application["qa_Server_Name"] = qa_homescreen_Server_dropdownlist.Text;
            Response.Redirect("CreateQAForm.aspx");
        }
    }
}